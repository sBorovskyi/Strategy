using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelctedVisual : MonoBehaviour
{
    [SerializeField] protected GameObject selectedVisual;
    [SerializeField] protected Unit unit;

    protected virtual void Start()
    {
        HideVisual();
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }

    private void UnitActionSystem_OnSelectedUnitChanged()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            ShowVisual();
        }
        else
        {
            HideVisual();
        }
    }

    protected virtual void ShowVisual()
    {
        selectedVisual.SetActive(true);
    }

    protected virtual void HideVisual()
    {
        selectedVisual.SetActive(false);
    }

}
