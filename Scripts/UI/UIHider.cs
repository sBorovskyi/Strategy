using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHider : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private KeyCode hideKey;


    private void Update()
    {
        if (Input.GetKey(hideKey))
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }
}
