using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] 
    Goal goalToObserve = null;

    Goal observedGoal = null;


    [SerializeField]
    Health healthToObserve = null;

    Health observedHealth = null;


    public GameObject victoryPanel;
    public GameObject defeatPanel;

    private void Awake()
    {
        StartObservingHealth(healthToObserve);

        StartObservingGoal(goalToObserve);
    }

    void StartObservingHealth(Health newHealthToObserver)
    {
        observedHealth = newHealthToObserver;

        
        observedHealth.Killed += OnObservedHealthKilled;
      
    }

    void StartObservingGoal(Goal newGoalToObserve)
    {
        observedGoal = newGoalToObserve;

        observedGoal.Victory += OnObservedVictory;
    }



    void OnObservedHealthKilled()
    {
        defeatPanel.SetActive(true);
    }


    void OnObservedVictory()
    {
        victoryPanel.SetActive(true);
    }
}
