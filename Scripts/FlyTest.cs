using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class FlyTest : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float angleInDegrees;

    private float g;

    private Rigidbody rigidbody;

  

    private void Start()
    {
  

        g = Physics.gravity.y;
        rigidbody  = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(clickRay, out RaycastHit hit))
        {
            endPoint.transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            transform.LookAt(endPoint);
            Jump();
        }
    }

    public void Jump()
    {

        startPoint.eulerAngles = new Vector3(-angleInDegrees, 0, 0) + transform.eulerAngles;

        Vector3 startPointXZ = new Vector3(startPoint.position.x, 0, startPoint.position.z);
        Vector3 endPointXZ = new Vector3(endPoint.position.x, 0, endPoint.position.z);

        float x = Vector3.Distance(startPointXZ, endPointXZ);
        float y = startPoint.position.y - endPoint.position.y;

        if (y < 0)
        {
            y *= -1;
        }

        float angleInRadians = angleInDegrees * Mathf.PI / 180;

        float formulaUp = g * Mathf.Pow(x, 2);
        float formulaDown = 2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2);

        float v = Mathf.Abs(Mathf.Sqrt(formulaUp / formulaDown));

        rigidbody.velocity = startPoint.forward * v;
    }
}
