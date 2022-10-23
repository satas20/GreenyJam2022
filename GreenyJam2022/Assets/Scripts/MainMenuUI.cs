using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public void PlayStory()
    {
        SceneManager.LoadScene("Story");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

