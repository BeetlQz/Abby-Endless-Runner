using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI batteryDisplay;
    [SerializeField] private TextMeshProUGUI GrindingDisplay;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    private void OnGUI()
    {
        scoreDisplay.text = ("Score ") + gameManager.scoreDisplay();

        batteryDisplay.text = ("Batteries ") + gameManager.batteryDisplay();


    }
    public void GrindScore(GrindableObjects grindableObjects)
    {
        GrindingDisplay.text = ("Grind Score ") + grindableObjects.ToString();
    }
}
