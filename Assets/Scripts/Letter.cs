using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public int id;
    public GameObject backGround;
    public GameObject letter;

    public void ChangeLetterTo(int letterId)
    {
        letter.GetComponent<Image>()
    }
}