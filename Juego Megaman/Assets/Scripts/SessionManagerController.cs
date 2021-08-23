using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManagerController : Singleton<SessionManagerController>
{
    Player player;

    protected override void Awake()
    {
        base.Awake();

        if (player == null)
        {
            lock (syncLock)
            {
                if (player == null)
                {
                    player = new Player();
                }
            }
        }
    }

}
