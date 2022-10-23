using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
  
    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }

        }

        }
        public void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;

        }

        void Paused()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;

        }

        public void QuitGame()
        {
        Debug.Log("b");

        Application.Quit();
        }
    }
