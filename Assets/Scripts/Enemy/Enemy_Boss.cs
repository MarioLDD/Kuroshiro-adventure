using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy
{




    private void Awake()
    {
        player = PlayerController.Instance.gameObject;
        enemyAnim = GetComponentInChildren<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.MaxHealth = enemyConfig.Health;

        weapon = weapon_GO.GetComponent<Weapon>();
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
        if (distanceToPlayer < distanceAttack)
        {
            //Pasar a aca la restriccion de tiempo para los ataques
            StartCoroutine(Attack());
        }
    }
    protected override void Move()
    {
        base.Move();
    }

    protected override IEnumerator Attack()
    {
        StartCoroutine(base.Attack());
        yield return null;
        //analizar que quiero que haga
    }

    public override void Dead()
    {
        base.Dead();
    }
}