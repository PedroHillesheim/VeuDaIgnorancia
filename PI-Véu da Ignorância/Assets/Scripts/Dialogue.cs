using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using static UnityEditor.ShaderData;
using System;

public class Dialogue: MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;
    public GameObject painelDialogo;
    public AudioSource [] Fala;
    public AudioSource Ambient;
    public int CurrentAudio = 0;

    void Start()
    {
        Ambient.Play();
        
        if (frases.Length > 0)
        {
            textoDialogo.text = frases[0];
        }
    }

    void Update()
    {
        SomAtual();
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
    public void SomAtual()
    {

        if (CurrentAudio < Fala.Length)
        {
            Fala[CurrentAudio].Play(); // Toca o áudio atual
            Invoke(nameof(SomAtual), Fala[CurrentAudio].clip.length); // Chama o próximo após o término
            CurrentAudio++; // Avança para o próximo áudio
        }
    }
}


   
