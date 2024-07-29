using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject pause_Panel;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject victory_Panel;
    [SerializeField] private GameObject gameOver_Panel;
    void Start()
    {
        pause_Panel.SetActive(false);
        nextLevel.SetActive(false);
        victory_Panel.SetActive(false);
        gameOver_Panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            pause_Panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pause_Panel.SetActive(false);
        }
    }
    public void OnGameOver()
    {
        gameOver_Panel.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnEnable()
    {
        HealthSystem_Player.OnPlayerHealthZero += OnGameOver;
    }

    private void OnDisable()
    {
        HealthSystem_Player.OnPlayerHealthZero -= OnGameOver;
    }

}