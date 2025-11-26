using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;
    public GameObject painelDialogo;
    public GameObject panel1;           // <-- ADICIONADO
    public AudioSource voiceSource;
    public AudioClip[] dublagens;
    public AudioSource ambientSource;

   void Start()
    {
        if (panel1 != null)
            panel1.SetActive(false);   // <--- Panel1 começa sempre desativado

        if (ambientSource != null)
            ambientSource.Play();

        if (frases != null && frases.Length > 0)
        {
            indice = 0;
            textoDialogo.text = frases[0];
            TocarDublagem(indice);
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

        if (indice < frases.Length)
        {
            textoDialogo.text = frases[indice];
            TocarDublagem(indice);
        }
        else
        {
            painelDialogo.SetActive(false);
            if (panel1 != null) panel1.SetActive(true); // <-- MOSTRA APÓS SUMIR
            Debug.Log("Fim do diálogo!");
        }
    }

    void TocarDublagem(int index)
    {
        if (voiceSource == null)
        {
            Debug.LogWarning("voiceSource não atribuído no Inspector!");
            return;
        }

        if (voiceSource.isPlaying)
        {
            voiceSource.Stop();
        }

        if (index < dublagens.Length && dublagens[index] != null)
        {
            voiceSource.clip = dublagens[index];
            voiceSource.Play();
            Debug.Log($"Tocando dublagem {index}: {dublagens[index].name}");
        }
        else
        {
            Debug.LogWarning($"Não há dublagem para índice {index}");
        }
    }
}
