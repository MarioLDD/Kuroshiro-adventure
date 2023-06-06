using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Barbarian : Enemy
{

    protected override void Move()
    {
       Vector2 moveDirection = player.position - gameObject.transform.position;
       float angle = Vector2.SignedAngle(Vector2.right, moveDirection);
       float distanceToPlayer = Vector2.Distance(player.position, gameObject.transform.position);

        if (distanceToPlayer < distanceDetection)
            {
                transform.eulerAngles = new Vector3(0, 0, angle);
                transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, speed * Time.deltaTime);
            }
        
}
}