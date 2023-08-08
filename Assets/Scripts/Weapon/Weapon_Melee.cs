using System.Collections;
using UnityEngine;

public class Weapon_Melee : Weapon
{
    void Awake()
    {
        damage = weaponConfig.Damage;
        attackRate = weaponConfig.AttackRate;
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
