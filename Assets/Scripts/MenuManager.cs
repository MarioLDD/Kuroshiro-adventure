using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pause_Panel;
    [SerializeField] private NextLevel nextLevel;

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
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pause_Panel.SetActive(false);
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