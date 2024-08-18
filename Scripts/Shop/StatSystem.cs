using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public static StatSystem Instance { get; private set; }

    [SerializeField] private int money;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int ammount)
    {
        money += ammount;
    }

    public void SpendMoney(int ammount)
    {
        if (CanSPendMoney(ammount))
        {
            money -= ammount;
        }
    }
        
    public bool CanSPendMoney(int ammount)
    {
        if (money >= ammount)
        {
            return true;
        }
        return false;
    }
}
