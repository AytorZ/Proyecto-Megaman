using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField]
    GameObject sparkles;

    SessionManagerController sessionManager;
    LevelManagerController levelManager;

    void Awake()
    {
        sessionManager = SessionManagerController.GetInstancia() as SessionManagerController;
        levelManager = FindObjectOfType<LevelManagerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(sparkles, transform.position, transform.rotation);
        Destroy(gameObject);

        FindObjectOfType<SceneLoaderController>().ProximaEscena();
    }
}