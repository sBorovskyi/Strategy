using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    [SerializeField] private string text = "Зареєструйтеся будь ласка";
    [SerializeField] private float printTime = 3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PrintText(Color.red));
        }
    }

    public IEnumerator PrintText(Color color)
    {
        yield return new WaitForSeconds(printTime);
        print(text);
    }
}
