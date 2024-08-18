using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private BaseUnitAction[] baseUnitActionsArray;

    private void Start()
    {
        baseUnitActionsArray = GetComponents<BaseUnitAction>();
    }

    public BaseUnitAction[] GetBaseUnitActions()
    {
        return baseUnitActionsArray;
    }
}
