using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    //public static event Action<int> OnHealthPotionEvent;
    [SerializeField] private int health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeHealth(health);
            //OnHealthPotionEvent?.Invoke(value);
            Destroy(gameObject);
        }
    }
}
