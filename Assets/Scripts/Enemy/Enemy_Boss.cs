using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy
{
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        Move();
    }
    protected override void Move()
    {
        base.Move();
    }

    protected override IEnumerator Attack()
    {
        base.Attack();
        yield return null;
        //analizar que quiero que haga
    }
}
