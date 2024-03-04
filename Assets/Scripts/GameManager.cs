using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public float CurrentScore = 0f;
    public bool IsPlaying = false;
    public float NumberofBatteries = 0f;


    [SerializeField] private UIManager uiManager;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public void BatteryCollected()
    {
     
    }

    public string scoreDisplay()
    {
        return Mathf.RoundToInt(CurrentScore).ToString();
    }

    public string batteryDisplay()
    {
        return Mathf.RoundToInt(NumberofBatteries).ToString();
    }

    public void GameOver() 
    {
        
        IsPlaying = false;
    }
    private void Update()
    {
        if (IsPlaying == true)
        {
            CurrentScore += Time.deltaTime;
            NumberofBatteries++;
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
