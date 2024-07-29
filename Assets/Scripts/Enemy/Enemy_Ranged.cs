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
        if (weapon_GO != null)
        {
            weapon = weapon_GO.GetComponent<Weapon>();
            weapon_GO.SetActive(false);
        }

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
        if (!isAttacking)
        {
            isAttacking = true;
            float attackRate = weapon.attackRate;
            if (Time.time >= lastShotTime + attackRate)
            {
                weapon.gameObject.SetActive(true);

                enemyAnim.SetTrigger("Attack");
                weapon.Attack();
                //yield return new WaitForSeconds(0.15f);
                weapon.gameObject.SetActive(false);
                lastShotTime = Time.time;
            }
            isAttacking = false;
        }
        yield return null;

    }
    public override void Dead()
    {
        base.Dead();
    }
}