using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRangeVisual : UnitSelctedVisual
{
    private ShootUnitAction unitAction;

    protected override void Start()
    {
        base.Start();


        if (TryGetComponent(out ShootUnitAction shootUnitAction))
        {
            unitAction = shootUnitAction;
        }
        else
        {
            Debug.LogError("Unit " + unit.name + " doesn't have ShootUnitActin \n " +
                           "You can use UnitRangeVisual only with ShootUnitAction");
        }
    }


    protected override void ShowVisual()
    {
        base.ShowVisual();

        selectedVisual.transform.localScale = Vector3.one * unitAction.GetShootRange() * 2;
    }

}
