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
    private int letterCounter;
    
    void Start()
    {
        //GetComponent<PopupHandler>().ShowMessage("test");
        instance = this;
        timer = 0;
        isLost = false;

        letterCounter = 0;
        madeWord.text = "";
        madeWordX = new List<int>();
        madeWordY = new List<int>();
    }

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

    public int AddLetter(int letterId, int x, int y)
    {
        print(Utility.dic_idToChar[letterId]);
        word += Utility.dic_idToChar[letterId];
        madeWord.text = word;
        
        madeWordX.Add(x);
        madeWordY.Add(y);
        letterCounter++;
        return letterCounter;
    }
    public void RemoveLetter(int letterNo, int x = -1, int y = -1)
    {
        print(Utility.dic_idToChar[letterNo]);
        word = word.Remove(letterNo-1,1);
        madeWord.text = word;
        print(word);
        
        madeWordX.RemoveAt(letterNo-1);
        madeWordY.RemoveAt(letterNo-1);
        letterCounter--;
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
            letterCounter = 0;
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