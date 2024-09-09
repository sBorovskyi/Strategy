using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlaceObjectAction : BaseUnitAction
{
    [SerializeField] private GameObject placementPrefab;
    [SerializeField] private float placementTime;

    private NavMeshAgent agent;

    private Vector3 targetPosition;
    private Vector3 startPosition;

    private bool isReachedTarget = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distanceToTarget;

        if (isReachedTarget == true)
        { 
           
            distanceToTarget  = Vector3.Distance(transform.position, startPosition);
            if (distanceToTarget <= 0.1f)
            {
                FinishAction();
                isReachedTarget = false;    
            }
        }
        else
        {
            distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            if (distanceToTarget <= 0.1f)
            {
                isReachedTarget = true;
                StartCoroutine(SpawnObject(targetPosition));
            }
        }
       
    }

    public override void UseAction(GameObject actionObject, Vector3 position)
    {
        base.UseAction(null, position);

        targetPosition = position;
        startPosition = transform.position;

        agent.SetDestination(position);
    }

    public IEnumerator SpawnObject(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(placementTime);
        Instantiate(placementPrefab, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(placementTime);
        agent.SetDestination(startPosition);
    }


}


















/*
private NavMeshAgent agent;

private bool targetIsReaced = false;
private Vector3 startPosition;
private Vector3 targetPosition;

private void Start()
{
    agent = GetComponent<NavMeshAgent>();
}

private void Update()
{
    if (!actionIsActive)
    {
        return;
    }


    if (targetPosition != null)
    {
        float distanceToTarget;

        if (targetIsReaced)
        {
            agent.SetDestination(startPosition);
            distanceToTarget = Vector3.Distance(transform.position, startPosition);
            if (distanceToTarget < 0.1f)
            {
                FinishAction();
            }
        }
        else
        {
            distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            if (distanceToTarget < 0.1f)
            {
                targetIsReaced = true;
            }
        }



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
    startPosition = transform.position;
    targetPosition = position;
}*/