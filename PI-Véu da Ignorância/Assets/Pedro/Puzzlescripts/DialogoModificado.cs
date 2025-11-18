using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogoModificado : MonoBehaviour
{
    public TMP_Text textoDialogo;
    public TMP_Text textoNome;
    public string[] frases;
    public string[] nomes;
    private int indice = 0;
    public string cena;
    [Header("Áudio")]
    public AudioSource voiceSource;      
    public AudioClip[] dublagens;        
    public AudioSource ambientSource;    

    void Start()
    {
        if (ambientSource != null)
            ambientSource.Play();

        if (frases != null && frases.Length > 0)
        {
            indice = 0;
            textoNome.text = nomes[0];
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
            textoNome.text = nomes[indice];
            textoDialogo.text = frases[indice];
            TocarDublagem(indice);
        }
        else
        {
            SceneManager.LoadScene(cena);
        }
    }

    void TocarDublagem(int index)
    {
        if (voiceSource == null)
        {
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
