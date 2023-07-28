using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private UnityEvent onHealthZero;

    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int CurrentHealth { get { return currentHealth; } }

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            onHealthZero.Invoke();
        }
    }
}
