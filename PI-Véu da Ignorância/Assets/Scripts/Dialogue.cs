using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;
    public GameObject painelDialogo;
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

        // Verifica se ainda há frases
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