using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalController : MonoBehaviour
{
    [SerializeField]
    Text marcadorTexto;

    [SerializeField]
    Text maximoTexto;

    [SerializeField]
    Text felicidadesTexto;

    SessionManagerController session;

    void Start()
    {
        session = SessionManagerController.GetInstancia() as SessionManagerController;

        int maximo = PlayerPrefs.GetInt("MaximoMarcador");
        int marcador = session.GetScore();

        marcadorTexto.text = marcador.ToString();
        felicidadesTexto.enabled = false;

        if (marcador > maximo)
        {
            PlayerPrefs.SetInt("MaximoMarcador", marcador);
            felicidadesTexto.enabled = true;
            maximo = marcador;
        }

        maximoTexto.text = maximo.ToString();
    }
}
