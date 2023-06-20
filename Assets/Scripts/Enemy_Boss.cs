using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enem
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnim = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        Move();
    }
    protected override void Move()
    {
        base.Move();
    }

    protected override void Attack()
    {
        base.Attack();
        //analizar que quiero que haga
    }
}
