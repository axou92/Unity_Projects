/*
This script control parametters of all scripts.
Each time a new scene is creating, adding this script to the main camera.
*/
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Default Parameters 

    // Actual time
    public static int actualTime = 1;
    
    // Audio
    public static float myVolume = 1; // Between 0 and 1
    public static bool mute = false;
    // Screen Resolution
    public static int resolutionX = 1200;
    public static int resolutionY = 640;
    // Screan Quality
    public static int qualityIndex = 2; // Between 0 and 5 (2 = Medium)
    
    // Public parameters 

    // Add audio source for sound during the game
    public AudioSource source;

    void Update()
    {
        Time.timeScale = actualTime;
        source.volume = myVolume;
        Screen.SetResolution(resolutionX, resolutionY, true);
    }

}
