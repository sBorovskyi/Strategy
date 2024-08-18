using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private Gradient gradient;

    private HealthComponent healthComponent;

    private void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
   
    }

    private void Update()
    {
        bar.fillAmount = healthComponent.GetHealth() / (float)healthComponent.GetMaxHealth();
        bar.color = gradient.Evaluate(bar.fillAmount);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthComponent.GetDamage(10);
        }
    }
}
