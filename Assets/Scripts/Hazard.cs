using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private float timeOut = 5;

    private float startTime;

    [SerializeField]
    int damage = 20;

    private void OnEnable()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if(Time.time -startTime > timeOut)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage);

            Destroy(gameObject);
        }
        
    }

}
