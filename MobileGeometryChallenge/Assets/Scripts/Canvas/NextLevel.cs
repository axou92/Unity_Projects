using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script open the new scene and indicate the number of the level. 
/// Optimisation possible between LevelMenu, NextLevel and Manager.
/// </summary>
public class NextLevel : MonoBehaviour
{
    public string numLevel;
    public string nextLevel;
    public static int theLevel;

    public void Next()
    {
        PauseMenu.gameIsPaused = false;        
        LevelMenu.Next_Level();
        Manager.manager.actualTime = 1;
        SceneManager.LoadScene(nextLevel);
    }

    public void Level()
    {
        Manager.manager.actualTime = 1;
        SceneManager.LoadScene(numLevel);
    }
}
