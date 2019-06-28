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
    public int x, y;
    public bool isSelected;

    void Start()
    {
        isSelected = false;
    }

    public void ChangeLetterTo(int letterId)
    {
        letter.GetComponent<SpriteRenderer>().sprite = ResourceManager.letters[letterId];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.AddLetter(id, x, y);
        print($"{id} Clicked");
    }

    public void DestroyLetter()
    {
        Destroy(gameObject);
    }
}