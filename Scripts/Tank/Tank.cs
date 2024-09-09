using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravityForce;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform leftTrackPoint;
    [SerializeField] private Transform rightTrackPoint;

    [SerializeField] private BoxCollider groundCheckCollider;
    [SerializeField] private LayerMask groundlayerMask;

    private Rigidbody rigidbody;

    private  Vector3 gravityVector = Vector3.zero;  
    private Vector3 moveVector = Vector3.zero;  

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
        float z = Input.GetAxis("Vertical");

        moveVector =  z * transform.forward;
   

        if (IsGrounded())
        {
            gravityVector.y = 0;
        }
        else
        {
            gravityVector.y -= gravityForce * Time.deltaTime;
        }

      

        rigidbody.velocity = moveVector * moveSpeed  + gravityVector;

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(rightTrackPoint.position, Vector3.up, rotateSpeed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(leftTrackPoint.position, Vector3.down, rotateSpeed * Time.deltaTime);
        }
        
      
    }


    private bool IsGrounded()
    {
        Vector3 overlapPosition = groundCheckCollider.transform.position + groundCheckCollider.center;
        Collider[] ovelapedColliders = Physics.OverlapBox(overlapPosition, 
                                                          groundCheckCollider.size / 2, 
                                                          groundCheckCollider.transform.rotation,
                                                          groundlayerMask);
        if (ovelapedColliders.Length  > 0)
        {
            return true;
        }

        return false;
    }
}
