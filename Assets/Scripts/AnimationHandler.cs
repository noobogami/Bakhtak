using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [UnityEditor.MenuItem("TestAnim/Create Test")]
    public static void CreateDropAnim (int valueStart, int valueEnd, int time = 1)
    {
        AnimationClip clip = new AnimationClip();
        //clip.SetCurve("", typeof(Transform), "position.x", AnimationCurve.EaseInOut(0, 0, 2, 10));
        clip.SetCurve("B_Normal", typeof(Transform), "position.y", AnimationCurve.EaseInOut(0, valueStart, time, valueEnd));
        clip.SetCurve("Icon", typeof(Transform), "position.y", AnimationCurve.EaseInOut(0, valueStart, time, valueEnd));
        //clip.SetCurve("", typeof(Transform), "position.z", AnimationCurve.EaseInOut(0, 5, 2, 2));
        AssetDatabase.CreateAsset(clip, "Assets/Animation/ScriptAnimation/LetterDrop.anim");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
