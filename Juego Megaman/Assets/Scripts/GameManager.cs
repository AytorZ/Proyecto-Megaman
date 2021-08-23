using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.GetInstancia() as AudioManager;
        if (!audioManager.IsPlayingSound("Title"))
        {
            audioManager.PlaySound("Title");
        }
    }
}
