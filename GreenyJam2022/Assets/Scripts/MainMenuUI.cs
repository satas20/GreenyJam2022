using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public GameObject Items;
    public GameObject Text;

    
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
    public void PlayGame()
    {

    }


    public void ChooseLevel()
    {
        
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
        BackButton();

    }
     public void BackButton()
    {
        Items.SetActive(true );
        Text.SetActive(false);
    }
   
   

    
}
