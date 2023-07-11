using System.Collections;
using UnityEngine;

public class Weapon_Ranged : Weapon
{
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
        proyectileRb = Instantiate(proyectile, transform.position, transform.rotation);
        proyectileRb.AddRelativeForce(Vector2.down * proyectileForce, ForceMode2D.Impulse);
    }
}
