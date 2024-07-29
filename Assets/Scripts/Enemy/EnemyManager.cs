using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [ReadOnly][SerializeField] private int maxEnemycount;
    [ReadOnly][SerializeField] private int enemycount;

    void Start()
    {
        maxEnemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void UpdateEnemyCount()
    {
        enemycount++;
        
        if(enemycount == maxEnemycount)
        {
            Debug.Log("Todos los enemigos estan muertos");
        }
    }
    private void OnEnable()
    {
        HealthSystem_Enemy.OnEnemyHealthZero += UpdateEnemyCount;
    }

    private void OnDisable()
    {
        HealthSystem_Enemy.OnEnemyHealthZero -= UpdateEnemyCount;
    }
}