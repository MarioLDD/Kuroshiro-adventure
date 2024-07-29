using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int actualScene;
    private int totalScenes;
    private int loadScene;
    public int LoadScene { get { return loadScene; } }
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject victory_Panel;


    void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
        //Debug.Log("total escenas " + totalScenes);
        actualScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            actualScene = SceneManager.GetActiveScene().buildIndex;
            if (totalScenes - 1 == actualScene)
            {
                victory_Panel.SetActive(true);
            }
            else
            {               
                loadScene = actualScene + 1;
                nextLevel.SetActive(true);
            }
            Time.timeScale = 0;
        }
    }
}