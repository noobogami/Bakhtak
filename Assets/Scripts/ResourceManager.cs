using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static Sprite[] letters;



    private void LoadLettersSprite()
    {
        letters = Resources.LoadAll<Sprite>("LetterPack");
    }
    
    
    
    void Awake()
    {
        LoadLettersSprite();
    }
}
