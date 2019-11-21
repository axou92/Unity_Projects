using UnityEngine;

/// <summary>
/// This script open the new scene.
/// Optimisation possible between LevelMenu, NextLevel and Manager.
/// </summary>
public class LevelMenu : MonoBehaviour
{
    public static int level = 1;

    public static void Next_Level()
    {
        if ( level == NextLevel.theLevel)
        {
            level += 1;
        }
    }

    public void Add_level()
    {
        Next_Level();
    }

}
