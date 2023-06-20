using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enem : MonoBehaviour
{
    protected GameObject player;
    protected Animator enemyAnim;


    [SerializeField] protected float speed = 1f;
    //points, puntaje para pasar al score acumulado
    [Tooltip("Green")]
    [SerializeField] protected float distanceDetection = 5f;

    [Tooltip("Gray")]
    [SerializeField] protected float distanceStop = 1f;

    [Tooltip("Red")]
    [SerializeField] protected float distanceAttack = 1f;

    protected virtual void Move()
    {
        Vector2 moveDirection = player.transform.position - gameObject.transform.position;
        moveDirection = moveDirection.normalized;

        float distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distanceToPlayer < distanceDetection)
        {
            enemyAnim.SetFloat("MovimientoX", moveDirection.x);
            enemyAnim.SetFloat("MovimientoY", moveDirection.y);
            if (distanceToPlayer > distanceStop)
            {
                enemyAnim.SetBool("IsMoving", true);

                transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                enemyAnim.SetBool("IsMoving", false);
            }
        }
        else
        {
            enemyAnim.SetBool("IsMoving", false);
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
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceDetection);

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceStop);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceAttack);
    }
}
