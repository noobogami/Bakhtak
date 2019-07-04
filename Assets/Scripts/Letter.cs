using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Letter : MonoBehaviour, IPointerClickHandler
{
    [FormerlySerializedAs("backGroundNormal")] public GameObject BNormal;
    [FormerlySerializedAs("backGroundSelected")] public GameObject BSelected;
    [FormerlySerializedAs("letter")] public GameObject letterImage;
    internal int id;
    internal int x, y;
    internal bool isSelected;
    
    public int selectedCount;

    void Start()
    {
        isSelected = false;
        selectedCount = -1;
        GraphicManager.instance.initLetter(this);
    }

    public void SetLetterId(int letterId)
    {
        letterImage.GetComponent<SpriteRenderer>().sprite = ResourceManager.letters[letterId];
        id = letterId;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.LetterClicked(this);
       
        print($"{Utility.dic_idToChar[id]} Clicked");
    }
}