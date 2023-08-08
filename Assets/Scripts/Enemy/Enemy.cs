using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    private float lastShotTime;
    private bool isAttacking = false;
    protected GameObject player;
    protected Animator enemyAnim;

    [SerializeField] protected EnemyConfig enemyConfig;
    [SerializeField] protected GameObject weapon_GO;
    [SerializeField] protected Weapon weapon;
    [SerializeField] protected float speed;
    [SerializeField] protected int points;
    [Tooltip("Green circle")]
    [SerializeField] protected float distanceDetection;

    [Tooltip("Gray circle")]
    [SerializeField] protected float distanceStop;

    [Tooltip("Red circle")]
    [SerializeField] protected float distanceAttack;
    protected HealthSystem healthSystem;
    protected float distanceToPlayer;



    [SerializeField] protected Transform hand;


    protected virtual void Move()
    {
        Vector2 moveDirection = player.transform.position - gameObject.transform.position;
        moveDirection = moveDirection.normalized;

        distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distanceToPlayer < distanceDetection)
        {
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

            // Rotate only the hand towards the player
            Vector3 pivot = transform.position;
            pivot.z = hand.position.z; // To ensure the Z-coordinate remains the same
            hand.RotateAround(pivot, Vector3.forward, targetAngle - hand.eulerAngles.z - 90);

            //rotacion en helicoptero
            //hand.RotateAround(transform.position, Vector3.forward, Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg);
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
        //////
        ///

    }

    protected virtual IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            float attackRate = weapon.attackRate;
            if (Time.time >= lastShotTime + attackRate)
            {
                enemyAnim.SetTrigger("Attack");
                Debug.Log("enemigo padre ataca");

                weapon.gameObject.SetActive(true);
                weapon.Attack();
                //weapon.transform.localPosition = Vector2.up * offSetAttack;
                yield return new WaitForSeconds(0.15f);
                //weapon.transform.localPosition = Vector2.zero;
                weapon.gameObject.SetActive(false);
                lastShotTime = Time.time;
            }
            isAttacking = false;
        }
    }

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
