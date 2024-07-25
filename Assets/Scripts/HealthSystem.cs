using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [ReadOnly][SerializeField] private int maxHealth;
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

    public void TakeHealth(int health)
    {

        if ((currentHealth + health) <= maxHealth)
        {
            currentHealth += health;

        }
        else
        {
            currentHealth = maxHealth;
        }

        if (iHealthBar != null)
        {
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }        
    }
    public void TakeHealth(int health,int healthIncrement)
    {
        maxHealth += healthIncrement;

        if ((currentHealth + health) <= maxHealth)
        {
            currentHealth += health;

        }
        else
        {
            currentHealth = maxHealth;
        }

        if (iHealthBar != null)
        {
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }
}