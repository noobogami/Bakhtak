using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHandler : MonoBehaviour
{
    public GameObject popupParent;
    public GameObject popup;
    public GameObject wrongMessageBar;

    public void ShowMessage(string message)
    {
        popup.SetActive(true);
        popupParent.SetActive(true);
        popup.GetComponentInChildren<Text>().text = message;
    }

    public void ShowError(String message)
    {
        
    }

    public void WrongWord()
    {
        wrongMessageBar.SetActive(true);
    }
}
