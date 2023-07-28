using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : Enemy
{
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnim = GetComponentInChildren<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.MaxHealth = enemyConfig.Health;
    }
    void Start()
    {
        points = enemyConfig.Points;
        speed = enemyConfig.Speed;
        distanceDetection = enemyConfig.DistanceDetection;
        distanceStop = enemyConfig.DistanceStop;
        distanceAttack = enemyConfig.DistanceAttack;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    protected override void Attack()
    {
        base.Attack();
        //Instancio proyectil, le doy impulso y le paso el daño que va a generar y el tarjet
    }
    public override void Dead()
    {
        base.Dead();
    }
}