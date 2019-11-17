/*
This script is automatically adding to a menuPannel. 
It controls a basic menu of a game with differents options.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelUI;
    public GameObject MenuUI;
    public GameObject OptionUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        Manager.actualTime = 1;
    }

    public void Level()
    {
        LevelUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void Option()
    {
        OptionUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void BackLevel()
    {
        LevelUI.SetActive(false);
        MenuUI.SetActive(true);
    }

    public void BackOption()
    {
        OptionUI.SetActive(false);
        MenuUI.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
