using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class MoveUnitAction : BaseUnitAction
{
    public event Action OnStartMove;
    public event Action OnStopMove;

    private bool isMoving = false;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if (!isMoving && agent.velocity != Vector3.zero)
        {
            isMoving = true;
            OnStartMove?.Invoke();
        }
        if (isMoving && agent.velocity == Vector3.zero)
        {
            isMoving = false;
            OnStopMove?.Invoke();
        }
    }

    public override void UseAction(GameObject actionObject, Vector3 position)
    {
        base.UseAction(null, position);

        Move(position);
    }

    public void Move(Vector3 position)
    {
        agent.SetDestination(position);
    }

}
