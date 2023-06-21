using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (BoxCollider2D))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IHealthSystem>() != null)
        {
            collision.gameObject.GetComponent<IHealthSystem>().TakeDamage(damage);
        }
    }
}
