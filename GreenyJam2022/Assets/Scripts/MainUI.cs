using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
   
    public static bool _gamePaused=false;
    public GameObject pause;

    private void Start()
    {
        pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true); 
            if (_gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
           
        }
    }

    void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        _gamePaused=true;
    }

  public  void ResumeGame()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        _gamePaused = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
       

    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
