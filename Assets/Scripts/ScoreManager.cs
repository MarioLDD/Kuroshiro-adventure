using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    void Start()
    {
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        Coin.OnCoinEvent += UpdateCoinText;
    }

    private void OnDisable()
    {
        Coin.OnCoinEvent -= UpdateCoinText;
    }

    private void UpdateCoinText(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}