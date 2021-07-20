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
                    ResetScore();
                }
            }
        }
    }

    public int GetScore()
    {
        return player.Score;
    }

    public void AddScore(int value)
    {
        player.Score += value;
    }

    public void ResetScore()
    {
        player.Score = 0;
    }
}
