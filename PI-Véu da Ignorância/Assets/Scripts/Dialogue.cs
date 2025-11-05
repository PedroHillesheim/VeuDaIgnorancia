using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue: MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;
    public GameObject painelDialogo;

    void Start()
    {
        if (frases.Length > 0)
        {
            textoDialogo.text = frases[0];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ProximaFrase();
        }
    }

    void ProximaFrase()
    {
        indice++;

        if (indice < frases.Length)
        {
            textoDialogo.text = frases[indice];
        }
        else
        {

            painelDialogo.SetActive(false);


         
        }
    }
}
