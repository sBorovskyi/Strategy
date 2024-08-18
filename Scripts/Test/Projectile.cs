using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private TransferData transferData;

    private Vector3 moveVector = Vector3.zero;

    private void Update()
    {
        transform.Translate(moveVector * transferData.MoveSpeed * Time.deltaTime);
    }


    private void OnGUI()
    {
        
    }

    private void HandleHit()
    {
        
    }

    public void Setup(TransferData transferData)
    {
        
        Transform target = transferData.Target;
        moveVector = (target.position - target.position).normalized;
    }

    public class TransferData
    {
        public Transform Target { get; private set; }
        public float MoveSpeed { get; private set; }
        public int Damage { get; private set; }

        public TransferData(Transform target, float moveSpeed, int damage)
        {
            Target = target;
            MoveSpeed = moveSpeed;
            Damage = damage;
        }
    }
}
