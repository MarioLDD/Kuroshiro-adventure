using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(HealthSystem))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    [SerializeField] private int health;
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform hand;
    [SerializeField] private Vector2 handPositionFront;
    [SerializeField] private Vector2 handPositionBack;
    [SerializeField] private Vector2 handPositionLeft;
    [SerializeField] private Vector2 handPositionRight;
    [SerializeField] private float offSetAttack;
    [SerializeField] private float radiointeraccion;
    [SerializeField] private LayerMask interactuableLayer;
    private Vector2 movement;
    private HealthSystem healthSystem;

    [SerializeField] private GameObject weapon;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.MaxHealth = health;
        weapon.SetActive(false);

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        playerAnim.SetFloat("MovimientoX", movement.x);
        playerAnim.SetFloat("MovimientoY", movement.y);
        playerAnim.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            playerAnim.SetFloat("LastMovimientoX", movement.x);
            playerAnim.SetFloat("LastMovimientoY", movement.y);
        }

        if (movement.y < 0) //Front Position
        {
            hand.localPosition = handPositionFront;
            hand.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (movement.y > 0) //Back Position
        {
            hand.localPosition = handPositionBack;
            hand.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (movement.x > 0) //Right Position
        {
            hand.localPosition = handPositionRight;
            hand.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (movement.x < 0) //Left Position
        {
            hand.localPosition = handPositionLeft;
            hand.rotation = Quaternion.Euler(0, 0, 90);
        }








        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }




    }


    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }

    /*private void Movement()
    {

    }*/

    private IEnumerator Attack()
    {
        playerAnim.SetTrigger("Attack");
        weapon.SetActive(true);

        weapon.transform.localPosition = Vector2.up * offSetAttack;
        yield return new WaitForSeconds(0.21f);
        //yield return null;

        weapon.transform.localPosition = Vector2.zero;
        weapon.SetActive(false);

    }


    private void Interactuar()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radiointeraccion, interactuableLayer);
        if (collider != null)
        {
            collider.gameObject.GetComponent<Iinteractuable>();//completar con la accion
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiointeraccion);
    }
}