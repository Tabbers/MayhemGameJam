using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DataStorage
{
    public const int maxNumberOfLevels = 9;

    public static int[] levels = new int[maxNumberOfLevels];
    public static int currentLevel = 0;

    public static int laseScene = 0;
    public static int chanceRun = 1;

    //MAKE THE PROTSGONIST MISERABLE !!!!!!!!!!!!!!!!
    public static long happines = 0;

    static public void MyShit()
    {
        levels[0] = 0;
        levels[1] = 1;
        levels[2] = 1;
        levels[3] = 2;
        levels[4] = 1;
        levels[5] = 3;
        levels[6] = 1;
        levels[7] = 4;
        levels[8] = 1;
    }

    static public void Randomise()
    {
        for(int i = 0; i< maxNumberOfLevels; ++i)
        {
            //Fix this when more scenes are added
            levels[i] = Mathf.FloorToInt(Random.value * 2);
        }
    }
}
