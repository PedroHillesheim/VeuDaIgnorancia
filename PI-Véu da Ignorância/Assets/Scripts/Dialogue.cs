using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textoDialogo;
    public string[] frases;
    private int indice = 0;
    public GameObject painelDialogo;

    [Header("Áudio")]
    public AudioSource voiceSource;      // Um único AudioSource que vai tocar as vozes
    public AudioClip[] dublagens;        // Clips correspondentes às frases (mesma ordem)
    public AudioSource ambientSource;    // opcional

    void Start()
    {
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
            // se quiser esperar o áudio terminar antes de avançar:
            // if (voiceSource != null && voiceSource.isPlaying) return;

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

        // Para o áudio atual (caso esteja tocando)
        if (voiceSource.isPlaying)
            voiceSource.Stop();

        // Toca clip correspondente se existir
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
