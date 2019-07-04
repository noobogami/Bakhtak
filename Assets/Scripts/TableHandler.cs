using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    public Letter[,] table;
    
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
        
        table = new Letter[columns, rows];
        CreatRow();
        CreatRow();
        CreatRow();
        CreatRow();
        
        Gravity();
    }
    private void ResetTable()
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
            height = GetAvailableHeight(position);
        }
        else
        {
            height = y;
        }
        if (height == -2)
        {
            throw new LostException();
        }
        
        
        
        table[position, height] = Instantiate(letterPrefab,letterParent).GetComponent<Letter>();
        table[position, height].transform.position =
            new Vector3(position * letterAxisToAxis + letterAxisToAxis/2 + LeftMargin, height * letterAxisToAxis + letterAxisToAxis/2 + bottomMargin , 0.0f);

        if (withAnimation)
        {
            table[position, height].GetComponent<Animator>().SetTrigger("DropFromTop");
            AnimationHandler.CreateDropAnim(0,100);
            //table[position, height].GetComponent<Animator>()
        }
        
        table[position, height].id = letterId;
        table[position, height].SetLetterId(letterId);
        table[position, height].x = position;
        table[position, height].y = height;
        //print($"{Utility.dic_idToChar[letterId]} created on " + position);
    }
    public void CreatRow()
    {
        for (int i=0; i<columns; i++)
        {
            CreateLetter(i);
        }
        
    }
    private int GetAvailableHeight(int column)
    {
        for (int i = 0; i < rows; i++)
        {
            if (table[column, i] == null)
            {
                return i;
            }
        }

        return -2;
    }
    public void PopLetters(List<Letter> popingLetter)
    {
        foreach (Letter letter in popingLetter)
        {
            DestroyImmediate(letter.gameObject);
        }
        
        Gravity();
    }
    private void Gravity()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (j > 0 && table[i, j] != null && table[i, j - 1] == null)
                {
                    //print("ready for droping " + table[i, j] + " " + i + " " + j);
                    DropLetter(table[i, j]);
                }

                //print(table[i, j]);
            }
        }
    }
    private void DropLetter(Letter letter, bool withAnimation = true)
    {
        int x = letter.x;
        int y = letter.y;
        //print("droping " + table[x, y] + " on " + table[x,y-1]);
        while (y > 0 && table[x, y - 1] == null)
        {
            //print("droping " + table[x, y]);
            table[x, y].y--;
            table[x, y].transform.position = new Vector3(x * letterAxisToAxis + letterAxisToAxis / 2 + LeftMargin,
                (y - 1) * letterAxisToAxis + letterAxisToAxis / 2 + bottomMargin, 0.0f);
            if (withAnimation)
            {
                table[x, y].GetComponent<Animator>().SetTrigger("DropOneRow");
            }
            
            table[x, y-1] = table[x,y];
            table[x, y] = null;
            y--;
        }
    }
}
public class LostException : Exception
{
}