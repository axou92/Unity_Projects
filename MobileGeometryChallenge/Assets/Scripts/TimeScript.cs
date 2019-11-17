using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public PlayerController player;

    public Text timerText;
    public float timeMax;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
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

        if (remainingTime <=0)
        {
            player.youLoose();   
        }
    }
}
