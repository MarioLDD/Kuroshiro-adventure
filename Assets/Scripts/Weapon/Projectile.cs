using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectile_Rb;
    private int damage;
    private float range;

    public Rigidbody2D Projectile_Rb { set { projectile_Rb = value; } }
    public int Damage { set { damage = value; } }
    public float Range { set { range = value; } }



    void Start()
    {
        float projectileVel = projectile_Rb.velocity.magnitude;
        Debug.Log("range: " + range + " vel: " + projectileVel);
        float time = range / projectileVel;
        Debug.Log("time: " + time); 
        Destroy(gameObject, time);
    }
    private void OnDisable()
    {
        Debug.Log("chauuuuu");
    }
    void Update()
    {
       // Debug.Log(projectile_Rb.velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}