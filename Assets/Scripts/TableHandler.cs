using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    public Letter[,] letter;
    public int rows, columns;
    public GameObject letterPrefab;
    public Transform letterParent;

    private float letterAxisToAxis;
    public static float letterSpacing;
    public static float letterDimension;
    public static float bottomMargin;
    public static float LeftMargin;

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
        letter[height, position] = Instantiate(letterPrefab,letterParent).GetComponent<Letter>();
        letter[height, position].transform.position =
            new Vector3(position * letterAxisToAxis + letterAxisToAxis/2 + LeftMargin, height * letterAxisToAxis + letterAxisToAxis/2 + bottomMargin , 0.0f);
        letter[height, position].GetComponent<Animator>().SetTrigger("DropFromTop");
        
        letter[height, position].id = letterId;
        letter[height, position].ChangeLetterTo(letterId);
        letter[height, position].x = position;
        letter[height, position].y = height;
        //print($"{Utility.dic_idToChar[letterId]} created on " + position);
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
        ResetTable();
        bottomMargin = 200;
        LeftMargin = 0;
        letterDimension = 130;
        letterSpacing = 5;
        letterAxisToAxis = letterDimension + letterSpacing;
        
        letter = new Letter[rows, columns];
        CreatRow();
        CreatRow();
        CreatRow();
        CreatRow();
        
        /*CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);*/
    }

    public void ResetTable()
    {
        for (int i = 0; i < letterParent.childCount; i++)
        {
            Destroy(letterParent.GetChild(i).gameObject);
        }
    }
    public void CreatRow()
    {
        for (int i=0; i<columns; i++)
        {
            CreateLetter(i);
        }
        
    }

    public void PopLetter(int x, int y)
    {
        int i;
        for (i = y; i < rows-1; i++)
        {
            print(i);
            if (letter[i+1,x] != null)
            {
                print($"destoryed {letter[i, x].id}");
                letter[i, x].DestroyLetter();
                letter[i, x] = Instantiate(letterPrefab, letterParent).GetComponent<Letter>();
                letter[i, x].GetComponent<Animator>().SetTrigger("DropOneRow");
                
                letter[i, x].y = i;
                letter[i, x].x = x;
                letter[i, x].id = letter[i + 1, x].id;
                letter[i, x].ChangeLetterTo(letter[i + 1, x].id);
                
                letter[i, x].transform.position =
                    new Vector3(x * letterAxisToAxis + letterAxisToAxis/2 + LeftMargin, i * letterAxisToAxis + letterAxisToAxis/2 + bottomMargin , 0.0f);
            }
            else
            {
                break;
            }
        }
        letter[i, x].DestroyLetter();
        letter[i, x] = null;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public class LostException : Exception
{
    
}