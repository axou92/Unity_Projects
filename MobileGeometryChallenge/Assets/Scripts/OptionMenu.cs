/*
This script control all option in the game.
It is possible to change all these options into the game or at the beginning.
*/
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    // GameObject
    public AudioSource source;
    public InputField resolutionX;
    public InputField resolutionY;
    public Dropdown quality;
    public Slider newVolume;
    public Toggle isMute;

    // Private variables
    int resX; // X resolution
    int resY; // Y resolutio,

    // Use parameters of the Manager when the scrpt is calling 
    void Start()
    {
        resX = Manager.resolutionX;
        resolutionX.text = resX.ToString();
        resY = Manager.resolutionY;
        resolutionY.text = resY.ToString();
        quality.value = Manager.qualityIndex;
        newVolume.value = Manager.myVolume;
        isMute.isOn = Manager.mute;
    }

    void Update()
    {
        // Set the quality (Medium by default)
        SetQuality();

        // Set the volume (Maximum by default)
        SetVolume();
    }

    void SetQuality()
    {
        Manager.qualityIndex = quality.value;
        QualitySettings.SetQualityLevel(Manager.qualityIndex);
    }

    void SetVolume()
    {
        if (isMute.isOn == true)
        {
            Manager.myVolume = 0;
            Manager.mute = true;
        }
        else
        {
            Manager.myVolume = newVolume.value;
            source.volume = newVolume.value;
        }
    }

    // This function is calling when the button "Change Resolution" is pressed 
    public void SetResolution()
    {
        if (resolutionX.text.Length > 0)
        {
            resX = int.Parse(resolutionX.text);
            Manager.resolutionX = resX;
        }
        else
        {
            resX = Manager.resolutionX;
            resolutionX.text = resX.ToString();
        }

        if (resolutionY.text.Length > 0)
        {
            resY = int.Parse(resolutionY.text);
            Manager.resolutionY = resY;
        }
        else
        {
            resY = Manager.resolutionY;
            resolutionY.text = resY.ToString();
        }
    }

    // This function is calling when the button "Reset" is pressed
    public void ResetValues()
    {
        Manager.myVolume = 1;
        Manager.resolutionX = 1024;
        Manager.resolutionY = 640;
        Manager.qualityIndex = 2;
        Manager.mute = false;

        resolutionX.text = Manager.resolutionX.ToString();
        resolutionY.text = Manager.resolutionY.ToString();
    }
}
