using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
   public GameObject Items;
    public GameObject Text;
    public static int selectedlevel;
    public int level;
    
    private void Awake()
    {
        if (Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }


    }

    void Start()
    {
        Items.SetActive(true);
        Text.SetActive(false);
    }

   
    void Update()
    {
        
    }
    public void PlayGame(string name)
    {
        name = "Level 1";
        SceneManager.LoadScene(name);
    }


    public void ChooseLevel()
    {
        selectedlevel = level;
        SceneManager.LoadScene("Level " + level.ToString());
       

    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

    public void Credits()
    {
        Items.SetActive(false);
        Text.SetActive(true);
        

    }
     public void BackButton()
    {
        Items.SetActive(true );
        Text.SetActive(false);
    }
   
   

    
}
