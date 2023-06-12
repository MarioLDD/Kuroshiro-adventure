using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : Enemy
{

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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
        //Instancio proyectil, le doy impulso y le paso el daño que va a generar y el tarjet
    }
}
