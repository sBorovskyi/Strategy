using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject unitObject;
 
    private void Start()
    {
        if (unitObject.TryGetComponent(out MoveUnitAction moveUnitAction))
        {
            moveUnitAction.OnStartMove += MoveUnitAction_OnStartMove;
            moveUnitAction.OnStopMove += MoveUnitAction_OnStopMove;
        }

        if (unitObject.TryGetComponent(out ShootUnitAction shootUnitAction))
        {
            shootUnitAction.OnShoot += ShootUnitAction_OnShoot;
        }

        if (unitObject.TryGetComponent(out GrenadeUnitAction grenadeUnitAction))
        {
            grenadeUnitAction.OnStartThrow += GrenadeUnitAction_OnStartThrow;
        }

       
    }

    private void GrenadeUnitAction_OnStartThrow()
    {
        animator.SetTrigger("Throw");
    }

    private void ShootUnitAction_OnShoot()
    {
        animator.SetTrigger("Shoot");
    }

    private void MoveUnitAction_OnStartMove()
    {
        animator.SetBool("Walk", true);
    }
    private void MoveUnitAction_OnStopMove()
    {
        animator.SetBool("Walk", false);
    }

}








/*
[SerializeField] private Animator animator;
[SerializeField] private GameObject unitObject;

private void Start()
{
    if (unitObject.TryGetComponent(out MoveUnitAction moveUnitAction))
    {
        moveUnitAction.OnStartMove += MoveUnitAction_OnStartMove;
        moveUnitAction.OnStopMove += MoveUnitAction_OnStopMove;
    }
    if (unitObject.TryGetComponent(out ShootUnitAction shootUnitAction))
    {
        shootUnitAction.OnShoot += ShootUnitAction_OnShoot;
    }
}

private void ShootUnitAction_OnShoot()
{
    animator.SetTrigger("Shoot");
}

private void MoveUnitAction_OnStartMove()
{
    animator.SetBool("Walk", true);
}
private void MoveUnitAction_OnStopMove()
{
    animator.SetBool("Walk", false);
}*/