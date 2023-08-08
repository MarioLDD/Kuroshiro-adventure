using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver_Panel;

    public void OnGameOver()
    {
        gameOver_Panel.SetActive(true);
        Time.timeScale = 0;
    }
}