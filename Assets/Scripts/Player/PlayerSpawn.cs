using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private bool spawnActive;
    void Start()
    {
        if (spawnActive)
            PlayerController.Instance.gameObject.transform.position = transform.position;
    }
}