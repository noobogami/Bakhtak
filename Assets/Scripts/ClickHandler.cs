using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler, IEndDragHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("draged");
        GameManager.instance.GetComponent<PopupHandler>().ShowMessage("Draged!");
        
    }
}
