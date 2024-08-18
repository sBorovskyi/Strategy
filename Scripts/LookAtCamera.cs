using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + camera.transform.forward);
        /*float distance = Vector3.Distance(camera.transform.position, transform.position);
        if (distance < 100)
        {
            transform.localScale = new Vector3(distance / 1000, distance / 1000, distance / 1000);
        }*/
       
    }
}
