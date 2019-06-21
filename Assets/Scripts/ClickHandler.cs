using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        print("draged");
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        print("clicked");
//        print("X: "+eventData.position.x);
//        print("Y: "+eventData.position.y);
    }
}
