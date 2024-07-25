using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private Vector2 movement;
    private HealthSystem healthSystem;
    private bool isAttacking = false;
    private bool canAttack = true;
    [SerializeField] private int health;
    [SerializeField] private float speed = 5;

    [Header("Current weapon")]
    [SerializeField] private Weapon weapon;
    private float lastShotTime;

    //[Header("Hand setting")]
    //[SerializeField] private Transform hand;
    [SerializeField] private float offSetAttack;//si no lo uso borrar
    //[SerializeField] private Vector2 handPositionFront;
    //[SerializeField] private Vector2 handPositionFrontL;
    //[SerializeField] private Vector2 handPositionLeft;
    //[SerializeField] private Vector2 handPositionBackL;
    //[SerializeField] private Vector2 handPositionBack;
    //[SerializeField] private Vector2 handPositionBackR;
    //[SerializeField] private Vector2 handPositionRight;
    //[SerializeField] private Vector2 handPositionFrontR;

    [Header("Interaction")]
    [SerializeField] private float radiointeraccion;
    [SerializeField] private LayerMask interactuableLayer;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.MaxHealth = health;
    }

    void Start()
    {
        UpdateWeapon();
    }

    void Update()
    {
        InputTeclado();

        Movement();
    }

    private void InputTeclado()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
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
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }

    private IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            float attackRate = weapon.attackRate;
            if (Time.time >= lastShotTime + attackRate)
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
                lastShotTime = Time.time;
            }
            isAttacking = false;
        }
    }

    private void Interactuar()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radiointeraccion, interactuableLayer);
        if (collider != null)
        {
            collider.gameObject.GetComponent<Iinteractuable>().Interaction();//completar con la accion
            if (collider.gameObject.tag == "CanNotAttack")
            {
                Debug.Log("NO puede atacar");
                canAttack = false;
            }
        }
        else
        {
            Debug.Log("puede atacar");

            canAttack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CanNotAttack")
        {
            Debug.Log("NO puede atacar");
            canAttack = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("puede atacar");
        canAttack = true;
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