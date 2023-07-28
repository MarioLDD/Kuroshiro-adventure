using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : Enemy
{
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
    }
    private void Start()
    {
        healthSystem.MaxHealth = enemyConfig.Health;
    }
    private void Start()
    {
        points = enemyConfig.Points;
        speed = enemyConfig.Speed;
        distanceDetection = enemyConfig.DistanceDetection;
        distanceStop = enemyConfig.DistanceStop;
        distanceAttack = enemyConfig.DistanceAttack;
    }
    private void Update()
    {
        Move();
    }


    protected override void Attack()
    {
        //activo animacion ataque, el que va a generar daño es el collider del arma
    }

    public override void Dead()
    {

    }
}