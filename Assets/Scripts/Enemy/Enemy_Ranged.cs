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

        //weapon_GO = enemyConfig.Weapon;
        weapon = weapon_GO.GetComponent<Weapon>();

    }
    void Start()
    {
        points = enemyConfig.Points;
        speed = enemyConfig.Speed;
        distanceDetection = enemyConfig.DistanceDetection;
        distanceStop = enemyConfig.DistanceStop;
        distanceAttack = enemyConfig.DistanceAttack;
    }
    void Update()
    {
        Move();
        if (distanceToPlayer < distanceAttack)
        {
            //Pasar a aca la restriccion de tiempo para los ataques
            StartCoroutine(Attack());
        }
    }
    protected override IEnumerator Attack()
    {
        StartCoroutine(base.Attack());
        yield return null;
    }
    public override void Dead()
    {
        base.Dead();
    }
}