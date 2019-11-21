using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is automatically adding to a pausePannel. 
/// It controls pause during the game and esc key is pressed.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// Public variables.
    [Header("Canvas")]
    public GameObject pauseMenuUI;
    public GameObject OptionUI;
    public GameObject GameUI;

    [Header("Level information")]
    public string num_level;

    public static bool gameIsPaused = false;

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    /// <summary> Function called to continue the game. </summary>
    public void Resume()
    {
        gameIsPaused = !gameIsPaused;
        pauseMenuUI.SetActive(gameIsPaused);
        GameUI.SetActive(!gameIsPaused);

        if (gameIsPaused)
        {
            Manager.manager.actualTime = 0;
        }
        else
        {
            Manager.manager.actualTime = 1;
        }
    }

    /// <summary> Function called to replay the level. </summary>
    public void Replay()
    {
        gameIsPaused = true;
        SceneManager.LoadScene(num_level);
        Resume();
    }

    /// <summary> Function called to change the game option. </summary>
    public void Option()
    {
        OptionUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        GameUI.SetActive(false);
    }

    /// <summary> Function called to return to the pause option. </summary>
    public void BackOption()
    {
        GameUI.SetActive(false);
        OptionUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    /// <summary> Function called to back to the menu of the game. </summary>
    public void Menu()
    {
        gameIsPaused = true;
        Manager.manager.actualTime = 0;
        SceneManager.LoadScene("Menu");
    }

    /// <summary> Function called to leave the game. </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
