using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using static UnityEditor.ShaderData;
using System;

public class Dialogue : MonoBehaviour
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
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        {
            textoDialogo.text = frases[0];
        }
        else
        {
            Debug.LogWarning("Nenhuma frase foi atribu�da ao di�logo!");
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

            // S� toca o �udio se existir um correspondente
            if (indice < Fala.Length && Fala[indice] != null)
            {
                Fala[indice].Play();
            }
        }
        else
        {
            // Fim do di�logo
            painelDialogo.SetActive(false);
            
            

         
        }

    }
    public void SomAtual()
    {

        if (CurrentAudio < Fala.Length)
        {
            Fala[CurrentAudio].Play(); // Toca o �udio atual
            Invoke(nameof(SomAtual), Fala[CurrentAudio].clip.length); // Chama o pr�ximo ap�s o t�rmino
            CurrentAudio++; // Avan�a para o pr�ximo �udio
        }
    }
}


   
