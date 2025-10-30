using UnityEngine;
using System.Collections; // Necessário para a Coroutine

public class TrocarMúsica : MonoBehaviour
{
    // O ÚNICO AudioSource na cena (o "toca-discos" que faz o som)
    public AudioSource audioPlayer;

    // As três músicas (os "discos" que serão colocados no toca-discos)
    public AudioClip clipPainel1;
    public AudioClip clipPainel2;
    public AudioClip clipPainel3;

    // GameObjects para os painéis (como antes)
    public GameObject painel1;
    public GameObject painel2;
    public GameObject painel3;

    private Coroutine musicRoutine;

    // Método seguro para iniciar uma nova música
    private void PlayNewMusicClip(AudioClip newClip)
    {
        // 1. Para qualquer rotina que possa estar rodando
        if (musicRoutine != null)
        {
            StopCoroutine(musicRoutine);
        }

        // 2. Inicia a rotina de transição
        musicRoutine = StartCoroutine(TransitionMusic(newClip));
    }

    // Coroutine para transição segura (Stop e Play)
    private IEnumerator TransitionMusic(AudioClip newClip)
    {
        if (audioPlayer == null)
        {
            Debug.LogError("ERRO: O AudioSource principal (audioPlayer) não foi atribuído no Inspector!");
            yield break; // Sai da função
        }

        // 1. Para o áudio atual
        audioPlayer.Stop();

        // Espera um frame (pequena pausa) para o Unity processar o Stop
        yield return null;

        // 2. Verifica se a nova música existe
        if (newClip != null)
        {
            // 3. Atribui a nova música ao AudioSource
            audioPlayer.clip = newClip;

            // 4. Toca a nova música
            audioPlayer.Play();
            Debug.Log($"Música: {newClip.name} iniciada no único AudioSource.");
        }
        else
        {
            Debug.LogWarning("AVISO: O AudioClip para este painel está faltando. Nenhuma música está tocando.");
        }

        musicRoutine = null;
    }

    // --- FUNÇÕES CHAMADAS PELO BOTÃO (ON CLICK) ---

    public void MostrarPainel1()
    {
        Debug.Log(">>> Chamado: MostrarPainel1() - Trocando para Painel 1.");

        // Lógica dos Painéis
        if (painel1 != null) painel1.SetActive(true);
        if (painel2 != null) painel2.SetActive(false);
        if (painel3 != null) painel3.SetActive(false);

        // Toca a música do Painel 1
        PlayNewMusicClip(clipPainel1);
    }

    public void MostrarPainel2()
    {
        Debug.Log(">>> Chamado: MostrarPainel2() - Trocando para Painel 2.");

        // Lógica dos Painéis
        if (painel1 != null) painel1.SetActive(false);
        if (painel2 != null) painel2.SetActive(true);
        if (painel3 != null) painel3.SetActive(false);

        // Toca a música do Painel 2
        PlayNewMusicClip(clipPainel2);
    }

    public void MostrarPainel3()
    {
        Debug.Log(">>> Chamado: MostrarPainel3() - Trocando para Painel 3.");

        // Lógica dos Painéis
        if (painel1 != null) painel1.SetActive(false);
        if (painel2 != null) painel2.SetActive(false);
        if (painel3 != null) painel3.SetActive(true);

        // Toca a música do Painel 3
        PlayNewMusicClip(clipPainel3);
    }
}