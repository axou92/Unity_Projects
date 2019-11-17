/*
This script open the new scene and indicate the number of the level. 
Optimisation possible between LevelMenu, NextLevel and Manager
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string num_level;
    public string next_level;
    public static int thelevel;

    public void next()
    {
        PauseMenu.gameIsPaused = false;        
        LevelMenu.Next_Level();
        Manager.actualTime = 1;
        SceneManager.LoadScene(next_level);
    }
    public void _level()
    {
        Manager.actualTime = 1;
        SceneManager.LoadScene(num_level);
    }
}
