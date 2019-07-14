using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isLost;
    
    private List<Letter> selectedLetters;

    private TableHandler tableHandler;
    private PopupHandler popupHandler;
    private GraphicManager graphicManager;
    private TimeManager timeManager;

    public RtlText madeWord;
    private string word;
    
    void Start()
    {
        instance = this;
        
        init();
    }

    private void init()
    {
        //GetComponent<PopupHandler>().ShowMessage("test");
        isLost = false;

        madeWord.text = "";
        
        selectedLetters = new List<Letter>();
        tableHandler = GetComponent<TableHandler>();
        popupHandler = GetComponent<PopupHandler>();
        graphicManager = GetComponent<GraphicManager>();
        timeManager = GetComponent<TimeManager>();
    }

    public void StartGame()
    {
        timeManager.ResetTimer();
    }
    void Update()
    {
        if (timeManager.IsDropTimeReached() && !isLost) 
        {
            try
            {
                tableHandler.CreateLetter();
            }
            catch (Exception e)
            {
                GameOver();
            }
        }
    }
    public void LetterClicked(Letter clickedLetter)
    {
        if (clickedLetter.isSelected)
        {
            RemoveLetter(clickedLetter);
            graphicManager.DeselectLetter(clickedLetter);
            clickedLetter.isSelected = false;
        }
        else
        {
            AddLetter(clickedLetter);
            graphicManager.SelectLetter(clickedLetter);
            clickedLetter.isSelected = true;
        }
    }
    public void AddLetter(Letter addingLetter)
    {
        selectedLetters.Add(addingLetter);
        
        word += Utility.dic_idToChar[addingLetter.id];
        madeWord.text = word;
    }
    public void RemoveLetter(Letter deselectedLetter)
    {
        for (int i = 0; i < selectedLetters.Count; i++)
        {
            if (deselectedLetter == selectedLetters[i])
            {
                selectedLetters.RemoveAt(i);
                print($"word no {i} deleted: " + word[i] + $" deselected letter was {Utility.dic_idToChar[deselectedLetter.id]}");
                word = word.Remove(i,1);
                break;
            }
        }
        madeWord.text = word;
        print(word);
    }
    
    public void RemoveAllLetters()
    {
        for (int i = 0; i < selectedLetters.Count; i++)
        {
            RemoveLetter(selectedLetters[i]);
        }
    }
    public void CheckWord()
    {
        if (DatabaseManager.instance.IsCorrect(word))
        {
            tableHandler.PopLetters(selectedLetters);
            
            word = "";
            selectedLetters = new List<Letter>();
            madeWord.text = word;
        }
        else
        {
            popupHandler.WrongWord();
        }
    }
    
    private void GameOver()
    {
        print("You Lost");
        popupHandler.ShowMessage("You Lost!");
        isLost = true;
    }
}