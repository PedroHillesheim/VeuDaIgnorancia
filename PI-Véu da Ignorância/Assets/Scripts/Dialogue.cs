using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
<<<<<<< Updated upstream
=======
using Unity.VisualScripting;
using System;
>>>>>>> Stashed changes

public class Dialogue : MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;
    public GameObject painelDialogo;
<<<<<<< Updated upstream

    void Start()
    {
        if (frases.Length > 0)
=======
    public AudioSource[] Fala;
    public AudioSource Ambient;
    public int CurrentAudio = 0;

    void Start()
    {
        if (Ambient != null)
        {
            Ambient.Play();
        }

        if (frases != null && frases.Length > 0)
>>>>>>> Stashed changes
        {
            textoDialogo.text = frases[0];
        }
        else
        {
            Debug.LogWarning("Nenhuma frase foi atribuída ao diálogo!");
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

<<<<<<< Updated upstream
=======
        // Verifica se ainda há frases
>>>>>>> Stashed changes
        if (indice < frases.Length)
        {
            textoDialogo.text = frases[indice];

            // Só toca o áudio se existir um correspondente
            if (indice < Fala.Length && Fala[indice] != null)
            {
                Fala[indice].Play();
            }
        }
        else
        {
            // Fim do diálogo
            painelDialogo.SetActive(false);
<<<<<<< Updated upstream


         
        }
    }
}
=======
            Debug.Log("Fim do diálogo!");
        }
    }

    public void SomAtual()
    {
        // Garante que não vá além do número de áudios
        if (CurrentAudio < Fala.Length && Fala[CurrentAudio] != null)
        {
            Fala[CurrentAudio].Play();
            Invoke(nameof(SomAtual), Fala[CurrentAudio].clip.length);
            CurrentAudio++;
        }
    }
}



>>>>>>> Stashed changes
