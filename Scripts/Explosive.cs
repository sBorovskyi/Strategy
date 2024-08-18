using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] protected GameObject explodeEffect;
    [SerializeField] protected float explodeRange;
    [SerializeField] protected float explodeTime;
    [SerializeField] protected int explodeDamage;

    [SerializeField] private string testVar = "Text";

    protected void Start()
    {
        StartCoroutine(Explode());
    }

    protected IEnumerator Explode()
    {
        yield return new WaitForSeconds(explodeTime);
        Collider[] explodedObjectsArray = Physics.OverlapSphere(transform.position, explodeRange);
        foreach (Collider explodedCollider in explodedObjectsArray)
        {
            if (explodedCollider.TryGetComponent(out HealthComponent healthComponent))
            {
                int resultDamage = CalculateDistanceDamage(explodedCollider.gameObject);
                healthComponent.GetDamage(resultDamage);
            }
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    protected int CalculateDistanceDamage(GameObject target)
    {
        float damagePerMeter = explodeDamage / explodeRange;
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        float damageResult = explodeDamage - damagePerMeter * distanceToTarget;
        return Mathf.RoundToInt(damageResult);
    }
}
