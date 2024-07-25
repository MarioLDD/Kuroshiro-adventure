using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncrement : MonoBehaviour
{
    //public static event Action<int> OnHeartIncrementEvent;
    [SerializeField] private int healthIncrement = 1;
    [SerializeField] private int health = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeHealth(health, healthIncrement);

            //OnHeartIncrementEvent?.Invoke(value);
            Destroy(gameObject);
        }
    }
}