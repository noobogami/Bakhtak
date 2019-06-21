using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    public Letter[,] letter;
    public int rows, columns;
    public GameObject letterPrefab;
    public GameObject letterParent;

    public void CreateLetter(int position = -1, int letterId = -1)
    {
        if (position == -1)
        {
            position = Utility.CreatRandom(0, columns);
        }

        if (letterId == -1)
        {
            letterId = Utility.CreatRandom(0, 32);
        }

        int height = Height(position);
        if (height == -2)
        {
            throw new LostException();
        }
        letter[height, position] = Instantiate(letterPrefab,letterParent.transform).GetComponent<Letter>();
        letter[height, position].transform.position =
            new Vector3(position * 135 + 67.5f, height * 135 + 67.5f + 200f, 0.0f);
        letter[height, position].id = letterId;
        letter[height, position].ChangeLetterTo(letterId);
        
    }

    private int Height(int column)
    {
        for (int i = 0; i < rows; i++)
        {
            if (letter[i, column] == null)
            {
                return i;
            }
        }

        return -2;
    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        letter = new Letter[rows, columns];
        CreatRow();
        CreatRow();
        CreatRow();
    }

    public void CreatRow()
    {
        for (int i=0; i<columns; i++)
        {
            CreateLetter(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public class LostException : Exception
{
    
}