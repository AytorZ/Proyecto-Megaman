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

    public void HealDamage(float heal)
    {
        if(healthController.GetHealth() < 100.0F)
        {
            healthController.Increase(heal);
        }
    }

    void Lose()
    {
        lose.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Win()
    {
        win.SetActive(true);
        gameObject.SetActive(false);
    }
}
