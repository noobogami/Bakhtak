using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    private static readonly System.Random r = new System.Random();

    static Utility()
    {
        InitDictionaries();
    }

    public static int CreatRandom(int min, int max)
    {
        return r.Next(min, max);
    }
    public static double CreatRandom()
    {
        return r.NextDouble();
    }

    public static int ConvertPixelToCordination(string axis, float value)
    {
        if (axis == "x")
        {
            //TODO: complete this shit
        }
        if (axis == "y")
        {
            //TODO: and also this fucker
        }
        return 0;
    }

    
    internal static Dictionary<char, int> dic_charToId;
    internal static Dictionary<int, char> dic_idToChar;
    
    private static void InitDictionaries()
    {
        dic_charToId = new Dictionary<char, int>
        {
            {' ', -1},
            {'ا', 0},
            {'آ', 0},
            {'ب', 1},
            {'پ', 2},
            {'ت', 3},
            {'ث', 4},
            {'ج', 5},
            {'چ', 6},
            {'ح', 7},
            {'خ', 8},
            {'د', 9},
            {'ذ', 10},
            {'ر', 11},
            {'ز', 12},
            {'ژ', 13},
            {'س', 14},
            {'ش', 15},
            {'ص', 16},
            {'ض', 17},
            {'ط', 18},
            {'ظ', 19},
            {'ع', 20},
            {'غ', 21},
            {'ف', 22},
            {'ق', 23},
            {'\u06A9', 24},
            {'\uFB8E', 24},
            {'\uFB8F', 24},
            {'\uFB90', 24},
            {'\uFB91', 24},
            {'گ', 25},
            {'ل', 26},
            {'م', 27},
            {'ن', 28},
            {'و', 29},
            {'ه', 30},
            {'\u064A', 31},
            {'\u0649', 31},
            {'\uFEF1', 31},
            {'\uFEF2', 31},
            {'\uFEF3', 31},
            {'\uFEF4', 31},
            {'\uFEEF', 31},
            {'\uFEF0', 31},
            {'\u06CC', 31}
        };


        dic_idToChar = new Dictionary<int, char>
        {
            {-1, ' '},
            {0, 'ا'},
            {1, 'ب'},
            {2, 'پ'},
            {3, 'ت'},
            {4, 'ث'},
            {5, 'ج'},
            {6, 'چ'},
            {7, 'ح'},
            {8, 'خ'},
            {9, 'د'},
            {10, 'ذ'},
            {11, 'ر'},
            {12, 'ز'},
            {13, 'ژ'},
            {14, 'س'},
            {15, 'ش'},
            {16, 'ص'},
            {17, 'ض'},
            {18, 'ط'},
            {19, 'ظ'},
            {20, 'ع'},
            {21, 'غ'},
            {22, 'ف'},
            {23, 'ق'},
            {24, 'ک'},
            {25, 'گ'},
            {26, 'ل'},
            {27, 'م'},
            {28, 'ن'},
            {29, 'و'},
            {30, 'ه'},
            {31, '\u06CC'}
        };
    }

    
}