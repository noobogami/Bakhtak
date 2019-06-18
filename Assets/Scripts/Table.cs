using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Letter[,] letter;
    public int rows, columns;
    public GameObject letterPrefab;


    public void MakeLetter(int position = -1)
    {
        System.Random r = new System.Random();
        if (position != -1)
        {
            position = r.Next(0, 8);
        }

        int hight = Hight(position);
        letter[position, hight] = Instantiate(letterPrefab).GetComponent<Letter>();
        letter[position, hight].transform.position =
            new Vector3(hight * 135 + 67.5f, position * 135 + 67.5f + 200f, 0.0f);
        letter[position, hight].id = position;
    }

    public int Hight(int column)
    {
        return 0;
    }

    // Use this for initialization
    void Start()
    {
        letter = new Letter[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                letter[i, j] = Instantiate(letterPrefab).GetComponent<Letter>();
                letter[i, j].transform.position = new Vector3(j * 135 + 67.5f, i * 135 + 67.5f + 200f, 0.0f);
                letter[i, j].id = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}