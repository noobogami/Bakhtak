using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Letter : MonoBehaviour , IPointerClickHandler, IEndDragHandler, IBeginDragHandler
{
    
    public int id;
    public GameObject backGround;
    public GameObject letter;

    public void ChangeLetterTo(int letterId)
    {
        letter.GetComponent<SpriteRenderer>().sprite = ResourceManager.letters[letterId];
    }
    

    public void OnEndDrag(PointerEventData eventData)
    {
        print("draged");
        GameManager.instance.GetComponent<PopupHandler>().ShowMessage("Draged!");
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print($" {id} Clicked");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("draged");
        GameManager.instance.GetComponent<PopupHandler>().ShowMessage("Draged!");
    }
}