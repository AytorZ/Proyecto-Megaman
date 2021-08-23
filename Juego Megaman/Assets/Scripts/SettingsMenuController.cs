using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    [SerializeField]
    Dropdown resolutionDropdown;

    [SerializeField]
    Dropdown qualityDropdown;

    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    Toggle fullScreenToggle;

    Resolution[] resolutions;
    
    void Start()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentOption = 0, optionCount =0;

        Array.ForEach
            (
                resolutions,
                resolution =>
                {
                    options.Add(resolution.width + " x " + resolution.height);
                    if
                        (
                            resolution.width == Screen.currentResolution.width &&
                            resolution.height == Screen.currentResolution.height
                        )
                    {
                        currentOption = optionCount;
                    }
                    optionCount++;
                }
            );

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentOption;
        resolutionDropdown.RefreshShownValue();

        optionCount = 0;
        options = new List<string>();
        foreach (string name in QualitySettings.names)
        {
            options.Add(name);
            if (optionCount == QualitySettings.GetQualityLevel())
            {
                currentOption = optionCount;
            }
            optionCount++;
        }

        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(options);
        qualityDropdown.value = currentOption;
        qualityDropdown.RefreshShownValue();

        float volume = 0F;
        audioMixer.GetFloat("volume", out volume);
        volumeSlider.value = volume;

        fullScreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
