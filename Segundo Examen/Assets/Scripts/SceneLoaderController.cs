using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderController : MonoBehaviour
{
    FaderController fader;
    SessionManagerController sessionManager = SessionManagerController.GetInstancia() as SessionManagerController;

    void Awake()
    {
        fader = FindObjectOfType<FaderController>();
    }

    void FadeAndLoadScene(int sceneIndex)
    {
        StartCoroutine(fader.FadeAndLoadScene(FaderController.FadeDirection.IN, sceneIndex));
    }

    /// <summary>
    /// Carga la siguiente escena a partir de la escena actual.
    /// </summary>
    public void ProximaEscena()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        FadeAndLoadScene(currentScene + 1);
    }

    /// <summary>
    /// Carga la primera escena del videojuego.
    /// </summary>
    public void PrimeraEscena()
    {
        FadeAndLoadScene(0);
        //sessionManager.ResetScore();
    }

    /// <summary>
    /// Carga la siguiente escena a partir de la escena actual.
    /// </summary>
    public void UltimaEscena()
    {
        fader.enabled = true;
        FadeAndLoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
