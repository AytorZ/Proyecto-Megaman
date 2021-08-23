using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    SessionManagerController sessionManager;
    // Start is called before the first frame update
    void Start()
    {
        sessionManager = SessionManagerController.GetInstancia() as SessionManagerController;
    }
}
