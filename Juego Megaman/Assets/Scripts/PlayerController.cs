using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject lose;

    [SerializeField]
    GameObject win;

    HealthController healthController;

    void Awake()
    {
        healthController = FindObjectOfType<HealthController>();
    }

    public void TakeDamage(float damage)
    {
        healthController.Decrease(damage);
        if (healthController.GetHealth() <= 0.0F)
        {
            Lose();
        }
    }

    void Lose()
    {
        lose.SetActive(true);
        //Invoke(nameof(ReloadScene), 2.0F);
        gameObject.SetActive(false);
    }

    public void Win()
    {
        win.SetActive(true);
        gameObject.SetActive(false);
    }

    //void ReloadScene()
    //{
    //    int currentScene = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(currentScene);
    //}
}
