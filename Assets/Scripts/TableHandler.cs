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
        
        letter = new Letter[columns, rows];
        /*CreatRow();
        CreatRow();
        CreatRow();
        CreatRow();*/
        
        /*CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);
        CreateLetter(0);*/
        
        CreateLetter(4,1,6, false);
        //CreateLetter(4,1,7, false);
        DropLetter(4,6);
    }
    public void ResetTable()
    {
        for (int i = 0; i < letterParent.childCount; i++)
        {
            Destroy(letterParent.GetChild(i).gameObject);
        }
    }
    public void CreateLetter(int position = -1, int letterId = -1, int y = -1, bool withAnimation = true)
    {
        if (position == -1)
        {
            position = Utility.CreatRandom(0, columns);
        }

        if (letterId == -1)
        {
            letterId = Utility.CreatRandom(0, 32);
        }

        int height;
        if (y == -1)
        {
            height = Height(position);
        }
        else
        {
            height = y;
        }
        if (height == -2)
        {
            throw new LostException();
        }
        
        
        
        letter[position, height] = Instantiate(letterPrefab,letterParent).GetComponent<Letter>();
        letter[position, height].transform.position =
            new Vector3(position * letterAxisToAxis + letterAxisToAxis/2 + LeftMargin, height * letterAxisToAxis + letterAxisToAxis/2 + bottomMargin , 0.0f);

        if (withAnimation)
        {
            letter[position, height].GetComponent<Animator>().SetTrigger("DropFromTop");
        }
        
        letter[position, height].id = letterId;
        letter[position, height].ChangeLetterTo(letterId);
        letter[position, height].x = position;
        letter[position, height].y = height;
        //print($"{Utility.dic_idToChar[letterId]} created on " + position);
    }
    public void CreatRow()
    {
        for (int i=0; i<columns; i++)
        {
            CreateLetter(i);
        }
        
    }
    private int Height(int column)
    {
        for (int i = 0; i < rows; i++)
        {
            if (letter[column, i] == null)
            {
                return i;
            }
        }

        return -2;
    }

    public void PopLetter(int x, int y)
    {
        int i;
        for (i = y; i < rows-1; i++)
        {
            print(i);
            if (letter[x, i+1] != null)
            {
                print($"destoryed {letter[x, i].id}");
                
                DropLetter(x, i);
                
                /*letter[x, i].DestroyLetter();
                letter[x, i] = Instantiate(letterPrefab, letterParent).GetComponent<Letter>();
                letter[x, i].GetComponent<Animator>().SetTrigger("DropOneRow");
                
                letter[x, i].y = i;
                letter[x, i].x = x;
                letter[x, i].id = letter[x, i+1].id;
                letter[x, i].ChangeLetterTo(letter[x, i+1].id);
                
                letter[i, x].transform.position =
                    new Vector3(x * letterAxisToAxis + letterAxisToAxis/2 + LeftMargin, i * letterAxisToAxis + letterAxisToAxis/2 + bottomMargin , 0.0f);*/
            }
            else
            {
                break;
            }
        }
        letter[x, i].DestroyLetter();
        letter[x, i] = null;
    }
    public void DropLetter(int x, int y, bool withAnimation = true)
    {
        while (letter[x, y - 1] != null && y > 0)
        {
            letter[x, y - 1] = Instantiate(letterPrefab, letterParent).GetComponent<Letter>();

            if (withAnimation)
            {
                letter[x, y - 1].GetComponent<Animator>().SetTrigger("DropOneRow");
            }
            
            letter[x, y - 1].y = y - 1;
            letter[x, y - 1].x = x;
            letter[x, y - 1].id = letter[x,y].id;
            letter[x, y - 1].ChangeLetterTo(letter[x, y].id);

            letter[x, y - 1].transform.position =
                new Vector3(x * letterAxisToAxis + letterAxisToAxis / 2 + LeftMargin,
                    (y - 1) * letterAxisToAxis + letterAxisToAxis / 2 + bottomMargin, 0.0f);

            letter[x, y].DestroyLetter();
            letter[x, y] = null;

            y--;
        }
    }
}
public class LostException : Exception
{
}