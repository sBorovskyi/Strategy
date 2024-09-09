using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHoloramVisuaL : MonoBehaviour
{
    [SerializeField] private Image image;
    private TImerHologram timerHologram;

    private void Start()
    {
        timerHologram = GetComponent<TImerHologram>();
    }

    private void Update()
    {
        image.fillAmount = timerHologram.GetTimerNormalized();
    }
}
