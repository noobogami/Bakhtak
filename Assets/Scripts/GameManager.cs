using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class GameManager : MonoBehaviour
{
    private float timer;
    public float dropLetterTime;
    public static GameManager instance;
    private bool isLost;
    private List<int> madeWordX;
    private List<int> madeWordY;

    public RtlText madeWord;
    private string word;
    
    void Start()
    {
        //GetComponent<PopupHandler>().ShowMessage("test");
        instance = this;
        timer = 0;
        isLost = false;
        
        madeWord.text = "";
        madeWordX = new List<int>();
        madeWordY = new List<int>();
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

    public void AddLetter(int letterId, int x, int y)
    {
        print(Utility.dic_idToChar[letterId]);
        word += Utility.dic_idToChar[letterId];
        madeWord.text = word;
        
        madeWordX.Add(x);
        madeWordY.Add(y);
    }

    public void CheckWord()
    {
        if (DatabaseManager.instance.IsCorrect(word))
        {
            PopLetters(word);
            
            word = "";
            madeWord.text = word;
            madeWordX = new List<int>();
            madeWordY = new List<int>();
        }
    }

    private void PopLetters(string popingWord)
    {
        for (int i = 0; i < popingWord.Length; i++)
        {
            GetComponent<TableHandler>().PopLetter(madeWordX[i], madeWordY[i]);
        }
    }

    private void GameOver()
    {
        print("You Lost");
        GetComponent<PopupHandler>().ShowMessage("You Lost!");
        isLost = true;
    }
    
    
}