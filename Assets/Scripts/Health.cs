using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action<int> Damaged = delegate { };
    public event Action<int> Healed = delegate { };
    public event Action Killed = delegate { };

    [SerializeField]
    int startingHealth = 100;
    public int StartingHealth => startingHealth;

    [SerializeField]
    int maxHealth = 100;
    public int MaxHealth => maxHealth;

    int currentHealth;

    public int CurrentHealth
    {
        get => currentHealth;

        set
        {
            if (value > maxHealth)
            {
                value = maxHealth;
            }
            currentHealth = value;
        }
    }


    private void Awake()
    {
        CurrentHealth = startingHealth;
    }


    public void Heal(int amount)
    {
        CurrentHealth += amount;
        Healed.Invoke(amount);
    }


    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        Damaged.Invoke(amount);

        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Killed.Invoke();
        gameObject.SetActive(false);
    }

}
