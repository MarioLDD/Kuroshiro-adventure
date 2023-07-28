using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private UnityEvent onHealthZero;
    private IHealthBar iHealthBar;

    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

    void Start()
    {
        currentHealth = maxHealth;
        if (GetComponentInChildren<IHealthBar>() != null)
        {
            iHealthBar = GetComponentInChildren<IHealthBar>();
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (iHealthBar != null)
        {
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        if (currentHealth < 1)
        {
            onHealthZero.Invoke();
        }
    }
}