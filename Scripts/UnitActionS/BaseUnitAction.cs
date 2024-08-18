using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseUnitAction : MonoBehaviour
{
    [SerializeField] protected string actionName;

    protected bool actionIsActive = false;

    public string GetActionName()
    {
        return actionName;
    }

    public virtual void UseAction(GameObject actionObject, Vector3 position)
    {
        if (actionIsActive == false)
        {
            actionIsActive = true;
        }
    }

    public void FinishAction()
    {
        actionIsActive = false;
    }
}
