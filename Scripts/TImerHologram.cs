using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImerHologram : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float spawnTime;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public float GetTimerNormalized()
    {
        return timer / spawnTime;
    }
}
