using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] private GameObject pause_Panel;
    [SerializeField] private NextLevel nextLevel;
    public bool IsPause;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        //GameObject nextLevel_Go = GameObject.Find("NextLevel");
        //if (nextLevel_Go != null)
        //{
        //    Debug.Log("existe");
        //    nextLevel = nextLevel_Go.GetComponent<NextLevel>();
        //}
    }
    private void Update()
    {

        if (!(SceneManager.GetActiveScene().name == "MainMenu"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }


        }
    }
    public void PauseGame()
    {
        IsPause = !IsPause;

        if (IsPause)
        {
            Time.timeScale = 0f;
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

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        int loadScene = nextLevel.LoadScene;
        SceneManager.LoadScene(loadScene);
    }



    public void SelectLevel()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}