using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    Slider health;

    public void Decrease(float value)
    {
        health.value -= value;
    }

    public void Increase(float value)
    {
        health.value += value;
    }

    public float GetHealth()
    {
        return health.value;
    }
}
