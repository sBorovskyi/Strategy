using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Axis axis;

    BoxCollider boxCollider;

    private void Update()
    {
       

        switch (axis)
        {
            case Axis.X:
                transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
                break;
            case Axis.Y:
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
                break;
            case Axis.Z:
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
                break;
        }
       
    }

}

public enum Axis
{
    X, Y, Z
}
