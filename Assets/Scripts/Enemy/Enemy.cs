using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Animator enemyAnim;

    [SerializeField] protected EnemyConfig enemyConfig;

    [SerializeField] protected float speed;
    [SerializeField] protected int points;
    [Tooltip("Green circle")]
    [SerializeField] protected float distanceDetection;

    [Tooltip("Gray circle")]
    [SerializeField] protected float distanceStop;

    [Tooltip("Red circle")]
    [SerializeField] protected float distanceAttack;
    protected HealthSystem healthSystem;

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

    protected virtual void Attack() { }

    public virtual void Dead()
    {
        Debug.Log("muerte de " + gameObject.name);

        //le paso el puntaje al GameManager, activo Animacion o efecto de muerte y destruyo el gameobject
        Destroy(gameObject);
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
