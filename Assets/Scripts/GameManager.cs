using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer;
    private float dropLetterTime;
    public static GameManager instance;
    private bool isLost;
    
    // Use this for initialization
    void Start()
    {
        //GetComponent<PopupHandler>().ShowMessage("test");
        dropLetterTime = 0.3f;
        instance = this;
        timer = 0;
        isLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > dropLetterTime && !isLost)
        {
            try
            {
                GetComponent<TableHandler>().CreateLetter();
            }
            catch (Exception e)
            {
                isLost = true;
                GameOver();
            }
            timer = 0;
        }

    }

    private void GameOver()
    {
        print("You Lose");
        GetComponent<PopupHandler>().ShowMessage("You Lose!");
    }
}