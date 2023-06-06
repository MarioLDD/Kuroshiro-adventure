using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    [SerializeField] private int maxHealth;
    private int currentHealth;



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            //activo particulas de muerte enemigo
            //sumo puntos al score
            Destroy(gameObject);
        }        
    }
}
