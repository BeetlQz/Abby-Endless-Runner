using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{

    GameManager gameManager;

    [SerializeField] private TextMeshProUGUI FinalScore;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LvL_Gameplay");
    }

    private void OnGUI()
    {
        FinalScore.text = ("Score ") + gameManager.scoreDisplay();

    }
}
