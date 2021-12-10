using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private float spwanRatePerMinute = 30;

    private int currentCount = 0;

    [SerializeField]
    private Vector3 spawnPoint;

    [SerializeField]
    private HazardFactory factory;

    [SerializeField]
    private float drawRadius = 1f;


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, drawRadius);

    }

    void Update()
    {
        var targetCount = Time.time * (spwanRatePerMinute / 60f);

        while(targetCount > currentCount)
        {
            var inst = factory.GetNewInstance();
            inst.transform.position = spawnPoint;

            currentCount++;
        }
    }
}
