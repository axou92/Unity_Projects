using UnityEngine;
using UnityEngine.UI;

/// <summary> This script allows to display the remaning time to finish the level. </summary>
public class TimeScript : MonoBehaviour
{
    /// Public variables.
    [Header("Script")]
    public PlayerController player;

    [Header("Time information")]
    public Text timerText;
    public float timeMax;

    /// Private variables.
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        DisplayRemaningTime();
    }

    /// <summary> Display the time with different color according to the remaning time. </summary>
    private void DisplayRemaningTime()
    {
        float t = Time.time - startTime;
        float remainingTime = timeMax - t;
        string time = remainingTime.ToString("f2");

        timerText.text = time;

        if (remainingTime > 15)
        {
            timerText.color = Color.green;
        }

        else if (remainingTime >= 6 && remainingTime <= 15)
        {
            timerText.color = Color.yellow;
        }

        else if (remainingTime < 6)
        {
            timerText.color = Color.red;
        }

        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        if (remainingTime <= 0)
        {
            player.YouLoose();
        }
    }
}
