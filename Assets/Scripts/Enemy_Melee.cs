using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : Enemy
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        //activo animacion ataque, el que va a generar daño es el collider del arma
    }
}