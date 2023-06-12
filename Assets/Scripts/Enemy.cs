using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    protected GameObject player;

    [SerializeField] protected float speed = 1f;
    //points, puntaje para pasar al score acumulado

    [SerializeField] protected float distanceDetection = 5f;//poner referencia en el inspector para saber que color le corresponde a cada radio
    [SerializeField] protected float distanceStop = 0f;
    [SerializeField] protected float distanceAttack = 0f;
    

    protected virtual void Move()
    {
        Vector2 moveDirection = player.transform.position - gameObject.transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, moveDirection);
        float distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distanceToPlayer < distanceDetection && distanceToPlayer > distanceStop)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Dead()
    {
        //le paso el puntaje al GameManager, activo Animacion o efecto de muerte y destruyo el gameobject
        //tambien considerar usar el sistema de vida aqui para no tener que estar llamando atantos script
    }
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceDetection);

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceStop);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceAttack);
    }
}
