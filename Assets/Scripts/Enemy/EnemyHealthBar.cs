using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour, IHealthBar
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float reduceSpeed = 2;
    private float target;
    void Start()
    {
        target = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, target, reduceSpeed * Time.deltaTime);
    }

    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        target = (float)currentHealth / maxHealth;
    }
}