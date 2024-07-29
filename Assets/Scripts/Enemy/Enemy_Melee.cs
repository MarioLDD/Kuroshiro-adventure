using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_Melee : Enemy
{
    [SerializeField] private float minwaitTime = 1f;
    [SerializeField] private float maxwaitTime = 3f;

    private float timer = 0.0f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.MaxHealth = enemyConfig.Health;

        //weapon_GO = enemyConfig.Weapon;
        if (weapon_GO != null)
        {
            weapon = weapon_GO.GetComponent<Weapon>();
            weapon_GO.SetActive(false);

        }
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

        if ((distanceToPlayer < distanceAttack) && !isAttacking)
        {
            timer += Time.deltaTime;
            //Pasar a aca la restriccion de tiempo para los ataques
            if (timer >= Random.Range(minwaitTime,maxwaitTime))
            {
                StartCoroutine(Attack());
                timer = 0.0f;
            }
        }
    }


    protected override IEnumerator Attack()
    {
        if (weapon == null)
            yield break;

        //Debug.Log("enemigo ataca");

        if (!isAttacking)
        {
            isAttacking = true;
            float attackRate = weapon.attackRate;
            if (Time.time >= lastShotTime + attackRate)
            {
                enemyAnim.SetTrigger("Attack");
                weapon_GO.SetActive(true);

                yield return new WaitForSeconds(.4f);

                weapon.Attack();
                weapon_GO.SetActive(false);
                lastShotTime = Time.time;
            }
            isAttacking = false;
        }
        yield return null;
        //activo animacion ataque, el que va a generar daño es el collider del arma
    }

    public override void Dead()
    {
        base.Dead();
    }
}