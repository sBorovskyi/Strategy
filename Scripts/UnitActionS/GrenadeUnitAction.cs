using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GrenadeUnitAction : BaseUnitAction
{
    [SerializeField] protected float useTime;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected float trowAngle;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected GameObject grenadePrefab;

    public event Action OnStartThrow;

    private Vector3 targetPosition;
    private bool isAimimg = false;
  

    private void Update()
    {
        if (isAimimg == true)
        {
            Vector3 lookDirection = (targetPosition - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, lookDirection, rotateSpeed * Time.deltaTime);
        }
    }

    public override void UseAction(GameObject actionObject, Vector3 position)
    {
        base.UseAction(actionObject, position);

        isAimimg = true;
        targetPosition = position;
        StartCoroutine(Throw());
       
    }


    private IEnumerator Throw()
    {
        OnStartThrow?.Invoke();
        yield return new WaitForSeconds(useTime);


        spawnPoint.transform.LookAt(transform.forward);
        spawnPoint.transform.eulerAngles = new Vector3(-trowAngle, 0, 0) + transform.eulerAngles;

        GameObject spawnedGrenade = Instantiate(grenadePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody spawnedGrenadeRB = spawnedGrenade.GetComponent<Rigidbody>();
        

        
        Vector3 targetDirection = targetPosition - transform.position;
        Vector3 targetDirectionXZ = new Vector3(targetDirection.x, 0, targetDirection.z);

        transform.forward = targetDirection;

        float x = targetDirectionXZ.magnitude;
        float y = targetDirection.y;

        float angleInRadians = trowAngle * Mathf.PI / 180;

        float v2 = (Physics.gravity.y * Mathf.Pow(x, 2) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2)));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        spawnedGrenadeRB.velocity = spawnPoint.transform.forward * v;

        isAimimg = false;

      
    }
}
