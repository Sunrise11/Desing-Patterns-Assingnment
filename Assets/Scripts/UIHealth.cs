using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIHealth : MonoBehaviour
{
    [SerializeField]
    Health healthToObserve = null;

    Health observedHealth = null;

    

    private void Awake()
    {
        StartObservingHealth(healthToObserve);
    }

    void StartObservingHealth(Health newHealthToObserver)
    {
        observedHealth = newHealthToObserver;

        observedHealth.Damaged += OnObservedHealthDamaged;
        observedHealth.Killed += OnObservedHealthKilled;
        observedHealth.Healed += OnObservedHealthHealed;
    }

    public void StopObservingHealth()
    {
        
        observedHealth.Damaged -= OnObservedHealthDamaged;
        observedHealth.Killed -= OnObservedHealthKilled;
        observedHealth.Healed -= OnObservedHealthHealed;

        observedHealth = null;
    }

    void OnObservedHealthDamaged(int damaged)
    {
        Debug.Log(damaged);
    }

    void OnObservedHealthKilled()
    {
        Debug.Log("Dead");
    }


    void OnObservedHealthHealed(int healed)
    {
        Debug.Log(healed);
    }
}
