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
        healthSystem.MaxHealth = enemyConfig.Health;

        //weapon_GO = enemyConfig.Weapon;
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


    protected override IEnumerator Attack()
    {
        Debug.Log("enemigo ataca");

        StartCoroutine(base.Attack());
        yield return null;
        //activo animacion ataque, el que va a generar daño es el collider del arma
    }

    public override void Dead()
    {
        base.Dead();
    }
}