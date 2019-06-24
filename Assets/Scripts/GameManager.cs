using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class GameManager : MonoBehaviour
{
    private float timer;
    private float dropLetterTime;
    public static GameManager instance;
    private bool isLost;

    public RtlText madeWord;
    private string word;
    
    void Start()
    {
        //GetComponent<PopupHandler>().ShowMessage("test");
        dropLetterTime = 1;
        instance = this;
        timer = 0;
        isLost = false;
        
        
        madeWord.text = "";
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
                GameOver();
            }
            timer = 0;
        }

    }

    public void AddLetter(int letterId)
    {
        print(Utility.dic_idToChar[letterId]);
        word += Utility.dic_idToChar[letterId];
        madeWord.text = word;
    }

    public void CheckWord()
    {
       // if (word)
    }
    private void GameOver()
    {
        print("You Lose");
        GetComponent<PopupHandler>().ShowMessage("You Lose!");
        isLost = true;
    }
    
    
}