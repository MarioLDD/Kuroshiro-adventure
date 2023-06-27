using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private Vector2 movement;
    private HealthSystem healthSystem;
    [SerializeField] private int health;
    [SerializeField] private float speed = 5;

    [Header("Current weapon")]
    [SerializeField] private Weapon weapon;

    [Header("Hand setting")]
    [SerializeField] private Transform hand;
    [SerializeField] private float offSetAttack;
    [SerializeField] private Vector2 handPositionFront;
    [SerializeField] private Vector2 handPositionFrontL;
    [SerializeField] private Vector2 handPositionLeft;
    [SerializeField] private Vector2 handPositionBackL;
    [SerializeField] private Vector2 handPositionBack;
    [SerializeField] private Vector2 handPositionBackR;
    [SerializeField] private Vector2 handPositionRight;
    [SerializeField] private Vector2 handPositionFrontR;

    [Header("Interaction")]
    [SerializeField] private float radiointeraccion;
    [SerializeField] private LayerMask interactuableLayer;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.MaxHealth = health;
        UpdateWeapon();
    }

    void Update()
    {
        InputTeclado();

        Movement();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }



    }

    private void InputTeclado()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }


    }

    private void Movement()
    {
        playerAnim.SetFloat("MovimientoX", movement.x);
        playerAnim.SetFloat("MovimientoY", movement.y);
        playerAnim.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            playerAnim.SetFloat("LastMovimientoX", movement.x);
            playerAnim.SetFloat("LastMovimientoY", movement.y);
        }

        if (movement.y < 0)
        {
            if (movement.x > 0) //Front-Right Position
            {
                hand.localPosition = handPositionFrontR;
                hand.rotation = Quaternion.Euler(0, 0, 225);
            }
            else if (movement.x < 0) //Front-Left Position
            {
                hand.localPosition = handPositionFrontL;
                hand.rotation = Quaternion.Euler(0, 0, 135);
            }
            else //Front Position
            {
                hand.localPosition = handPositionFront;
                hand.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else if (movement.y > 0)
        {
            if (movement.x > 0) //Back-Right Position
            {
                hand.localPosition = handPositionBackR;
                hand.rotation = Quaternion.Euler(0, 0, 315);
            }
            else if (movement.x < 0) //Back-Left Position
            {
                hand.localPosition = handPositionBackL;
                hand.rotation = Quaternion.Euler(0, 0, 45);
            }
            else //Back Position
            {
                hand.localPosition = handPositionBack;
                hand.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (movement.x > 0) //Right Position
        {
            hand.localPosition = handPositionRight;
            hand.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (movement.x < 0) //Left Position
        {
            hand.localPosition = handPositionLeft;
            hand.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }

    private IEnumerator Attack()
    {
        playerAnim.SetTrigger("Attack");
        if (weapon != null)
        {
            weapon.gameObject.SetActive(true);
            weapon.Attack();
            //weapon.transform.localPosition = Vector2.up * offSetAttack;
            yield return new WaitForSeconds(0.15f);
            //weapon.transform.localPosition = Vector2.zero;
            weapon.gameObject.SetActive(false);
        }
    }

    private void Interactuar()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radiointeraccion, interactuableLayer);
        if (collider != null)
        {
            collider.gameObject.GetComponent<Iinteractuable>().Interaction();//completar con la accion
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiointeraccion);
    }
    public void UpdateWeapon()
    {
        if (GetComponentInChildren<Weapon>() != null)
        {
            weapon = GetComponentInChildren<Weapon>();

            weapon.gameObject.SetActive(false);
        }
    }
}