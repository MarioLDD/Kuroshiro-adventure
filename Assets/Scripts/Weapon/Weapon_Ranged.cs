using System.Collections;
using UnityEngine;

public class Weapon_Ranged : Weapon
{
    [SerializeField] Transform firePoint;
    void Start()
    {
        damage = weaponConfig.Damage;
        attackRate = weaponConfig.AttackRate;
        range = weaponConfig.Range;
        startAmmo = weaponConfig.StartAmmo;
        proyectileForce = weaponConfig.ProyectileForce;
        proyectile = weaponConfig.Proyectile;
    }

    public override void Attack()
    {
        Rigidbody2D proyectileRb;
        proyectileRb = Instantiate(proyectile, firePoint.position, transform.rotation);
        proyectileRb.AddRelativeForce(Vector2.down * proyectileForce, ForceMode2D.Impulse);
        Projectile projectile = proyectileRb.gameObject.GetComponent<Projectile>();
        projectile.Projectile_Rb = proyectileRb;
        projectile.Damage = damage;
        projectile.Range = range;
    }
}
