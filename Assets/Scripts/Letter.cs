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
    private bool isSelected;
    private int selectedCount;

    void Start()
    {
        isSelected = false;
        selectedCount = -1;
        VisualyStart();
    }

    public void ChangeLetterTo(int letterId)
    {
        letterImage.GetComponent<SpriteRenderer>().sprite = ResourceManager.letters[letterId];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSelected)
        {
            isSelected = false;
            GameManager.instance.RemoveLetter(selectedCount);
            selectedCount = -1;
            
            VisualyDeselectLetter();
        }

        else if (!isSelected)
        {
            isSelected = true;
            selectedCount = GameManager.instance.AddLetter(id, x, y);
            
            VisualySelectLetter();
        }

        print($"{Utility.dic_idToChar[id]} Clicked");
    }

    public void VisualyStart()
    {
        BNormal.SetActive(true);
        BSelected.SetActive(false);
        letterImage.SetActive(true);
    }
    public void VisualySelectLetter()
    {
        BNormal.SetActive(false);
        BSelected.SetActive(true);
    }
    public void VisualyDeselectLetter()
    {
        BNormal.SetActive(true);
        BSelected.SetActive(false);
    }
    public void DestroyLetter()
    {
        Destroy(gameObject);
    }
}