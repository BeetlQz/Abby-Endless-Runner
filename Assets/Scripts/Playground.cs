using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{       
    public int Health = 0;
    public int MaxHealth = 7;
    bool isPlayerAlive = true;
    string AliveMsg = "Oh no";
    string DeadMsg = "Fuck";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Health);
        Debug.Log(MaxHealth);

        if (Health < MaxHealth){
            isPlayerAlive = false;
        }
        else {
            isPlayerAlive = true;
        }

        if(isPlayerAlive == false)
        {
            Debug.Log(DeadMsg);
        }
        else {
            Debug.Log(AliveMsg);
        }
    }

    // Update is called once per frame
    void Update()
    {
      

    }
}
