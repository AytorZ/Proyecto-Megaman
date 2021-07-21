using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerController : MonoBehaviour
{
    int hp = 100;

    public void damage(int amount)
    {
        hp = hp - amount;
    }

    public int getHealth()
    {
        return hp;
    }
}
