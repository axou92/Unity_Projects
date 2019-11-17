/*
This script open the new scene.
Optimisation possible between LevelMenu, NextLevel and Manager
*/
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    public static int level = 1;

    public static void Next_Level()
    {
        if ( level == NextLevel.thelevel)
        {
            level += 1;
        }
    }

    public void add_level()
    {
        Next_Level();
    }

}
