using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    private static readonly System.Random r = new System.Random();



    public static int CreatRandom(int min, int max)
    {
        return r.Next(min, max);
    }
    public static double CreatRandom()
    {
        return r.NextDouble();
    }
}