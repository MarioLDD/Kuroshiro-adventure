using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform hand;
    [SerializeField] private float radiointeraccion;
    [SerializeField] private LayerMask interactuableLayer;
    private Vector2 movement;

    public GameObject weapon;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
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
            hand.localPosition = new Vector2(-0.02f, -0.08f);
            hand.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (movement.y > 0) //Back Position
        {
            hand.localPosition = new Vector2(-0.03f, 0.08f);
            hand.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (movement.x > 0) //Right Position
        {
            hand.localPosition = new Vector2(0.08f, -0.04f);
            hand.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (movement.x < 0) //Left Position
        {
            hand.localPosition = new Vector2(-0.08f, -0.04f);
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

        weapon.transform.localPosition = Vector2.up * 0.01f;
        yield return new WaitForSeconds(0.02f);
        //yield return null;

        weapon.transform.localPosition = Vector2.zero;
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