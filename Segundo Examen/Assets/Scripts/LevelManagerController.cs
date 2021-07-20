using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerController : MonoBehaviour
{
    int breakableBricks = 0;

    public void countBreakableBrick()
    {
        breakableBricks++;
    }

    public void breakBrick()
    {
        breakableBricks--;
    }

    public int getBreakableBricks()
    {
        return breakableBricks;
    }
}
