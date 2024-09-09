using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ShootUnitAction : BaseUnitAction
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private int damage;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float shootOffset;
    [SerializeField] private float shootRange;

    public event Action OnShoot;

    private Vector3 target;


    private bool isAimimg = false;


    private void Update()
    {
        if (isAimimg == true)
        {
            Vector3 lookDirection = (target - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, lookDirection, rotateSpeed * Time.deltaTime);
        }
    }

    public void TryShoot(GameObject shootObject)
    {
        Vector3 shootDirection = (shootObject.transform.position - shootPoint.position).normalized;
        Ray shootRay = new Ray(shootPoint.position, shootDirection);
        if (Physics.Raycast(shootRay, out RaycastHit raycastHit, shootRange))
        {
            if (raycastHit.collider.gameObject.TryGetComponent(out EnemyUnit enemyUnit))
            {
                isAimimg = true;
                target = shootObject.transform.position;
                StartCoroutine(Shoot(enemyUnit.gameObject));
                OnShoot?.Invoke();
            }
        }
    }

    private IEnumerator Shoot(GameObject shootObject)
    {
        yield return new WaitForSeconds(shootOffset);
        isAimimg = false;
        GameObject spawnedBulletObject = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet spawnedBullet = spawnedBulletObject.GetComponent<Bullet>();
        spawnedBullet.Setup(shootObject.transform.position);

        if (shootObject.TryGetComponent(out HealthComponent healthComponent))
        {
            healthComponent.GetDamage(damage);
        }
    }

    public float GetShootRange()
    {
        return shootRange;
    }


    public override void UseAction(GameObject actionObject,Vector3 position)
    {
        base.UseAction(actionObject ,position);

        TryShoot(actionObject);
    }
}
