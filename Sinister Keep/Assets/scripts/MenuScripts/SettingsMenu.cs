using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider darknessSlider;
    public Toggle fullScreenToggle;

    private void Awake()
    {
        float volumeValue;
        audioMixer.GetFloat("volume", out volumeValue);
        volumeSlider.value = volumeValue;

        darknessSlider.value = RenderSettings.sun.intensity;

        fullScreenToggle.isOn = Screen.fullScreen;
    }

    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetLightIntensity(float intensity)
    {
        RenderSettings.sun.intensity = intensity;
    }

}
