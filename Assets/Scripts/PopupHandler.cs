using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHandler : MonoBehaviour
{
    public GameObject popupParent;
    public GameObject popup;

    public void ShowMessage(string message)
    {
        popup.SetActive(true);
        popupParent.SetActive(true);
        popup.GetComponentInChildren<Text>().text = message;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
