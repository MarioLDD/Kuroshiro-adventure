using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     protected Transform player;
    [SerializeField] private float speed = 1f;
    [SerializeField] protected float distanceDetection = 5f;


    protected virtual void Move(){}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceDetection);
    }

}
