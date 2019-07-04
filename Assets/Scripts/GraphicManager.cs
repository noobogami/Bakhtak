using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicManager : MonoBehaviour
{
    internal static GraphicManager instance;
    void Start()
    {
        instance = this;
    }

    public void initLetter(Letter targetLetter)
    {
        targetLetter.BNormal.SetActive(true);
        targetLetter.BSelected.SetActive(false);
        targetLetter.letterImage.SetActive(true);
    }
    public void SelectLetter(Letter targetLetter)
    {
        targetLetter.BNormal.SetActive(false);
        targetLetter.BSelected.SetActive(true);
    }

    public void DeselectLetter(Letter targetLetter)
    {
        targetLetter.BNormal.SetActive(true);
        targetLetter.BSelected.SetActive(false);
    }


}
