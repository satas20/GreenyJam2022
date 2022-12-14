using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI Water;
    public TextMeshProUGUI health;
    int score=1;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        score = PlayerMovement.WaterCount;
        Water.text = "X" + PlayerMovement.WaterCount.ToString();
        if (PlayerMovement.WaterCount == 0)
        {
            health.text = "X" + PlayerMovement.WaterCount.ToString();

        }
        if (PlayerMovement.WaterCount == 0) 
        {
            Reload();
            
        }

    }
    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
