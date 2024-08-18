using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private Transform target; 

    public void Shoot()
    {
        GameObject newBulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Projectile newProjectile = newBulletObj.GetComponent<Projectile>();

        Projectile.TransferData transferData = 
            new Projectile.TransferData(target, speed, damage);

        newProjectile.Setup(transferData);

    }


}
