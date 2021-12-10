using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    int restore = 100;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.Heal(restore);

            Destroy(gameObject);
        }

    }
}
