using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonName;
    [SerializeField] private Button button;
    

    public void SetButtonName(string name)
    {
        buttonName.text = name;
   
    }

    public Button GetButton()
    {
        return button;
    }

}
















/*[SerializeField] private TextMeshProUGUI buttonName;
    [SerializeField] private Button button;

    public void SetButtonName(string name)
    {
        buttonName.text = name;
    }

    public Button GetButton()
    {
        return button;  
    }*/