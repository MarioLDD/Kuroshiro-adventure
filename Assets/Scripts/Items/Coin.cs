using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action<int> OnCoinEvent;
    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCoinEvent?.Invoke(value);
            Destroy(gameObject);
        }
    }
}