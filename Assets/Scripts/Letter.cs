using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Letter : MonoBehaviour, IPointerClickHandler
{
    public GameObject BNormal;
    public GameObject BSelected;
    public SpriteRenderer letterImage;
    internal int id;
    internal int x, y;
    internal bool isSelected;
    

    void Start()
    {
        isSelected = false;
        GraphicManager.instance.initLetter(this);
    }

    public void SetLetterId(int letterId)
    {
        letterImage.sprite = ResourceManager.letters[letterId];
        id = letterId;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.LetterClicked(this);
       
        print($"{Utility.dic_idToChar[id]} Clicked");
    }
}