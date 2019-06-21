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
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        LoadLettersSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
