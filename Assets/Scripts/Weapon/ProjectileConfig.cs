using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Create Projectile")]
public class ProjectileConfig : ScriptableObject
{
    [SerializeField] private int damage;

    [SerializeField] private float range;

    public int Damage { get { return damage; } }
    public float Range { get { return range; } }
}