using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is used only on the tutorial scene.
/// It allows to learn the basic of this game.
/// Some instrction will appear with the explanation.
/// </summary>
public class Tutorial : MonoBehaviour
{
    /// Public variables.
    [Header("Panels")]
    public GameObject welcomePanel;
    public GameObject obstaclePanel;
    public GameObject jumpPanel;
    public GameObject goalPanel;
    public GameObject endPanel;

    [Header("Animation")]
    public Animator obstacleWall;
    public Animator jumpWall;
    public Animator goalWall;

    public void ValidateInstruction()
    {
        welcomePanel.SetActive(false);
        obstaclePanel.SetActive(false);
        jumpPanel.SetActive(false);
        goalPanel.SetActive(false);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary> 
    /// Regroup all tutorial event. 
    /// These events are add to the player event which already exist.
    /// </summary>
    /// <param name="colInfo"> Gameobject which the player enter in collision. </param>
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        /// Case where the movement tutorial is ending.
        if (other.gameObject.CompareTag("MOVEMENT"))
        {
            obstacleWall.SetTrigger("Enter");
            obstaclePanel.SetActive(true);
        }

        /// Case where the obstacle tutorial is ending.
        if (other.gameObject.CompareTag("OBSTACLE"))
        {
            jumpWall.SetTrigger("Enter");
            jumpPanel.SetActive(true);
        }

        /// Case where the jump tutorial is ending.
        if (other.gameObject.CompareTag("JUMP"))
        {
            goalWall.SetTrigger("Enter");
            goalPanel.SetActive(true);
        }

        /// Case where the tutorial is ending.
        if (other.gameObject.CompareTag("END"))
        {
            endPanel.SetActive(true);
        }
    }

}
