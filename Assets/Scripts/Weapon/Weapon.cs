using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponConfig weaponConfig;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackRate;

    [Header("Only for range weapons")]
    [SerializeField] protected float range;
    [SerializeField] protected int startAmmo;
    [SerializeField] protected int proyectileForce;
    [SerializeField] protected Rigidbody2D proyectile;
    public virtual void Attack()
    {

    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.TakeDamage(damage);
        }
    }
}