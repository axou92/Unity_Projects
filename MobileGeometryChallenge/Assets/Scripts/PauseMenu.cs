/*
This script is automatically adding to a pausePannel. 
It controls pause during the game and esc key is pressed.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string num_level; // Indicate the scene name when you want to replay
    public static bool gameIsPaused = false; // Indicate if the game is in pause
    public GameObject pauseMenuUI; // Select the panel
    public GameObject OptionUI;
    public GameObject GameUI;

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        gameIsPaused = !gameIsPaused;
        pauseMenuUI.SetActive(gameIsPaused);
        GameUI.SetActive(!gameIsPaused);

        if (gameIsPaused)
        {
            Manager.actualTime = 0;
        }
        else
        {
            Manager.actualTime = 1;
        }
    }

    public void Replay()
    {
        gameIsPaused = true;
        SceneManager.LoadScene(num_level);
        Resume();
    }

    public void Option()
    {
        OptionUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        GameUI.SetActive(false);
    }

    public void BackOption()
    {
        GameUI.SetActive(false);
        OptionUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void Menu()
    {
        gameIsPaused = true;
        Manager.actualTime = 0;
        SceneManager.LoadScene("Menu");
        // Resume();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
