using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
