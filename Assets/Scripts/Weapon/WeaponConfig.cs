using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Create Weapon")]
public class WeaponConfig : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float attackRate;

    [SerializeField] private float range = 0;
    //[SerializeField] private string type;
    [SerializeField] private int startAmmo = 0;
    [SerializeField] private int proyectileForce = 0;
    [SerializeField] private Rigidbody2D proyectile;

    public int Damage { get { return damage; } }
    public float AttackRate { get { return attackRate; } }
    public float Range { get { return range; } }
    //public string Type { get { return type; } }
    public float FireRate { get { return attackRate; } }
    public int StartAmmo { get { return startAmmo; } }
    public int ProyectileForce { get { return proyectileForce; } }
    public Rigidbody2D Proyectile { get { return proyectile; } }
}
