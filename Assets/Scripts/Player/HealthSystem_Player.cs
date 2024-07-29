using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem_Player : HealthSystem
{
    public static event Action OnPlayerHealthZero;

    protected override void OnHealthZero()
    {
        OnPlayerHealthZero?.Invoke();
    }

    public void TakeHealth(int health)
    {
        currentHealth += health * 4;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (iHealthBar != null)
        {
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    public void TakeHealth(int health, int healthIncrement)
    {
        maxHealth += healthIncrement * 4;
        currentHealth += health * 4;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (iHealthBar != null)
        {
            iHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }
}