using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DataStorage
{
    public const int maxNumberOfLevels = 10;

    public static int[] levels = new int[maxNumberOfLevels];
    public static int currentLevel = -1;

    //MAKE THE PROTSGONIST MISERABLE !!!!!!!!!!!!!!!!
    public static long happines = -10000000;

    static public void Randomise()
    {
        for(int i = 0; i< maxNumberOfLevels; ++i)
        {
            //Fix this when more scenes are added
            levels[i] = Mathf.FloorToInt(Random.value * 2);
        }
    }
}
