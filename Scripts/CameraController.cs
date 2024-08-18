using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public int moveSpeed;
    public int rotateSpeed;
    public int scrollSpeed;
    public int scrollSensetivity;
    public int scrollStopSensetivity;
    public int minY;
    public int maxY;
    public bool scrollIvnverted;
    Vector3 scrollVector = Vector3.zero;
    private CinemachineTransposer transposer;

    private void Start()
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        Vector3 moveVector = Vector3.zero;
        Vector3 rotateVector = Vector3.zero;

        if (Input.mouseScrollDelta.y == 0)
        {
            scrollVector = Vector3.Lerp(scrollVector, Vector3.zero, scrollStopSensetivity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W)) moveVector.z = 1;
        if (Input.GetKey(KeyCode.S)) moveVector.z = -1;
        if (Input.GetKey(KeyCode.D)) moveVector.x = 1;
        if (Input.GetKey(KeyCode.A)) moveVector.x = -1;

        transform.Translate(moveVector * moveSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.E)) rotateVector.y = 1;
        if (Input.GetKey(KeyCode.Q)) rotateVector.y = -1;

        transform.Rotate(rotateVector * rotateSpeed * Time.deltaTime);

        if (scrollIvnverted)
        {
            scrollVector.y += Input.mouseScrollDelta.y * scrollSensetivity;
        }
        else
        {
            scrollVector.y += -Input.mouseScrollDelta.y * scrollSensetivity;
        }
        

        Vector3 startCameraPoint = transposer.m_FollowOffset;
        Vector3 finalCameraPoint = transposer.m_FollowOffset + scrollVector;

        

        transposer.m_FollowOffset = Vector3.Lerp(startCameraPoint, finalCameraPoint, scrollSpeed * Time.deltaTime);
        transposer.m_FollowOffset.y = Mathf.Clamp(transposer.m_FollowOffset.y, minY, maxY);
    }
}
