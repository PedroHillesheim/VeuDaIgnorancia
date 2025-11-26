using UnityEngine;
using TMPro;

public class dialogue1 : MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;

    public GameObject painelDialogo;
    public GameObject painelDepois;   // ← ADICIONADO

    public AudioSource voiceSource;
    public AudioClip[] dublagens;
    public AudioSource ambientSource;

    void Start()
    {
        if (ambientSource != null)
        {
            ambientSource.Play();
        }

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
            painelDialogo.SetActive(false);     // Desativa painel principal

            if (painelDepois != null)
            {
                painelDepois.SetActive(true);   // ← Ativa o Painel (1)
            }

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
