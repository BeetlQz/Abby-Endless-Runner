using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
            //connect to game manager and trigger Game Over
        }

        if (other.transform.tag == "grindObstacle")
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }

        if (other.transform.tag == "Battery")
        {
            other.gameObject.SetActive(false);
            Battery battery = other.gameObject.GetComponent<Battery>();

            battery.Collected();
        }
    }
    
}
