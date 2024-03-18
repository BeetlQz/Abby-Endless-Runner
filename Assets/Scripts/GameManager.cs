using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public float CurrentScore = 0f;
    public bool IsPlaying = false;
    // public float CurrentBatteries = 0f;


    [SerializeField] private UIManager uiManager;

    public GameOverScreen gameOverScreen;

   
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
   /* public void BatteryCollected()
    {
        CurrentBatteries++;
    } */

    public string scoreDisplay()
    {
        return Mathf.RoundToInt(CurrentScore).ToString();
    }

   /* public string batteryDisplay()
   {
        return Mathf.RoundToInt(CurrentBatteries).ToString();
    } */

    public void GameOver() 
    {
        
        IsPlaying = false;

        SceneManager.LoadScene("RestartScreen");

      //  GameOverScreen.Setup();
    }
    private void Update()
    {
        if (IsPlaying == true)
        {
            CurrentScore += Time.deltaTime;
  
        }

        if (Input.GetKeyDown("p"))
        {
            IsPlaying = true;
        }
    }

    public void StartGame()
    {
        CurrentScore = 0f;    
        IsPlaying=true;
       // uiManager.ButtonPlay.gameobject.setactive(false);

        
    }


}
