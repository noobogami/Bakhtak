using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TimeManager : MonoBehaviour
{
    private float gameTimer, start, timer;

    public float dropLetterTime;
    void Start()
    {
        start = Time.time;
        gameTimer = 0;
        timer = 0;
    }
    void Update()
    {
        gameTimer += Time.deltaTime;
        timer += Time.deltaTime;
    }
    internal void ResetTimer()
    {
        gameTimer = 0;
        timer = 0;
    }

    internal bool IsDropTimeReached()
    {
        if (timer > dropLetterTime)
        {
            timer = 0;
            return true;
        }

        return false;
    }
}
