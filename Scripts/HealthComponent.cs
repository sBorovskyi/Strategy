using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Heal(int healing)
    {
        health += healing;
        if (health > maxHealth)
        {
            healing = maxHealth;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
