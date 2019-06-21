using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Letter : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public GameObject backGround;
    public GameObject letter;

    public void ChangeLetterTo(int letterId)
    {
        letter.GetComponent<SpriteRenderer>().sprite = ResourceManager.letters[letterId];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.AddLetter(id);
        print($"{id} Clicked");
    }
}