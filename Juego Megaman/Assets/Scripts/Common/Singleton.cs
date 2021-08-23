using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    static Singleton<T> instancia;
    protected static readonly object syncLock = new object();

    protected virtual void Awake()
    {
        bool destroyMe = true;

        if (instancia == null)
        {
            lock (syncLock)
            {
                if (instancia == null)
                {
                    instancia = this;
                    DontDestroyOnLoad(gameObject);
                    destroyMe = false;
                }
            }
        }

        if (destroyMe)
        {
            Destroy(gameObject);
            return;
        }

        // Solo se ejecuta la primera vez
    }

    public static Singleton<T> GetInstancia()
    {
        return instancia;
    }
}
