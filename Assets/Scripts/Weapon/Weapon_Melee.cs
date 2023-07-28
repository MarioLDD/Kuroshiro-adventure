using System.Collections;
using UnityEngine;

public class Weapon_Melee : Weapon
{
    void Start()
    {
        damage = weaponConfig.Damage;
        //attackRate = weaponConfig.AttackRate;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
