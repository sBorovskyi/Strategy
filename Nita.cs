using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nita : MonoBehaviour
{
    public int speed = 50;
    public int gravityForce = 50;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();  
    }


    private void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(Vector3.forward *  speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(Vector3.back *  speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(Vector3.left *  speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(Vector3.right *  speed * Time.deltaTime);
        }

        characterController.Move(Vector3.down * gravityForce * Time.deltaTime);
    }
}
