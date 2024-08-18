using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject destroyFX;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 moveVector;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);
        float fromStartToEndDistance = Vector3.Distance(startPosition, targetPosition);
        float fromStartToBulletDistance = Vector3.Distance(startPosition, transform.position);

        if (fromStartToBulletDistance >= fromStartToEndDistance)
        {
            Destroy(gameObject);
            Instantiate(destroyFX, targetPosition, Quaternion.identity);
        }
    }



    public void Setup(Vector3 targetPosition)
    {

        Vector3 xzTargetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        this.targetPosition = xzTargetPosition;
        moveVector = (xzTargetPosition - transform.position).normalized;
    }
}
