using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public bool isGameOver;
    public bool PassedDoor;
    public GameObject panel;
    
    void Start()
    {
        panel.SetActive(false);
        isGameOver = false;
        PassedDoor = false;
    }

    void Update()
    {
        if (PassedDoor == true)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        panel.SetActive(true);
    }
}
