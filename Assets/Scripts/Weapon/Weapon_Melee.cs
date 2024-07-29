using System.Collections;
using UnityEngine;

public class Weapon_Melee : Weapon
{
    void Awake()
    {
        damage = weaponConfig.Damage;
        attackRate = weaponConfig.AttackRate;
    }
    private void OnEnable()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
    protected override void OnTriggerStay2D(Collider2D collision)
    {

        base.OnTriggerStay2D(collision);
        gameObject.GetComponent<Collider2D>().enabled = false;        
    }
}
