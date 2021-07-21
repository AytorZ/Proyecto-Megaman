using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorController : MonoBehaviour
{
    Text contadortext;
    float contadorTime = 120;
    // Start is called before the first frame update
    void Start()
    {
        contadortext = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (contadorTime > 0)
        {
            contadorTime -= Time.deltaTime;
            contadortext.text = contadorTime.ToString();
        }
        else
        {
            contadortext.text = contadorTime.ToString();
            FindObjectOfType<SceneLoaderController>().ProximaEscena();
        }
    }
}
