using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    AudioManager audioManager;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        audioManager = AudioManager.GetInstancia() as AudioManager;
        if (currentScene == "Inicio")
        {
            audioManager.StopSound("Game");
            audioManager.PlaySound("Title");
        }
        if (currentScene == "Nivel 1")
        {
            audioManager.StopSound("Title");
            audioManager.PlaySound("Game");
        }
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Inicio")
        {
            if (!audioManager.IsPlayingSound("Title"))
            {
                audioManager.StopSound("Game");
                audioManager.PlaySound("Title");
            }
            
        }
        if (currentScene == "Nivel 1")
        {
            if (!audioManager.IsPlayingSound("Game"))
            {
                audioManager.StopSound("Title");
                audioManager.PlaySound("Game");
            }
        }
    }
}
