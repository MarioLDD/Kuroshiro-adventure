using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private string enemyName;
    //[SerializeField] private string enemyType;//ver si lo uso
    [SerializeField] private int health;
    [SerializeField] private int points;
    [SerializeField] private float speed;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float distanceDetection;
    [SerializeField] private float distanceStop;
    [SerializeField] private float distanceAttack;

    public int Health { get { return health; } }
    public int Points { get { return points; } }
    public float Speed { get { return speed; } }
    public GameObject Weapon { get { return weapon; } }    
    public float DistanceDetection { get { return distanceDetection; } }
    public float DistanceStop { get { return distanceStop; } }
    public float DistanceAttack { get { return distanceAttack; } }
}
