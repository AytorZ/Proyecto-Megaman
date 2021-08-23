using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    GameObject settingsMenu;

    bool isPaused = false;

    void Update()
    {
        ProcessPause();
    }

    void ProcessPause()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0F;
        settingsMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1F;
        settingsMenu.SetActive(false);
    }
}
