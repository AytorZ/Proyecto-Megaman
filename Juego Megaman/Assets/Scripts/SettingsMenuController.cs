using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    [SerializeField]
    Scrollbar volumeSlider;

    SessionManagerController sessionManager;

    void Awake()
    {
        sessionManager = SessionManagerController.GetInstancia() as SessionManagerController;
    }

    void Start()
    {

        float volume = 0F;
        audioMixer.GetFloat("volume", out volume);
        volumeSlider.value = volume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
