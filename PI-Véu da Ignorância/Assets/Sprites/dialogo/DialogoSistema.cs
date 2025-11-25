using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogoSistema : MonoBehaviour
{
    [Header("Referências")]
    public DialogoData dialogueData;

    public AudioClip letraClip;
    public AudioSource audioSource; // ← adiciona esse AudioSource

    public TMP_Text dialogueText;
    public TMP_Text nomeText;

    public float typingSpeed = 0.03f;

    [Header("Configurações")]
    public bool mudaCenaAoTerminar = false;
    public string nextSceneName = "";

    private int currentLine = 0;
    private bool isTyping = false;
    private bool dialogoAtivo = false;
    private bool aguardandoTrocaCena = false;

    void Start()
    {
        if (dialogueData != null)
            IniciarDialogo();

        // garante que não está tocando no começo
        if (audioSource != null)
            audioSource.loop = true;
    }

    void Update()
    {
        if (aguardandoTrocaCena)
        {
            if (Input.GetKeyDown(KeyCode.F))
                TrocarCena();
            return;
        }

        if (!dialogoAtivo)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueData.falas[currentLine].texto;

                // 🔊 PARA O SOM IMEDIATAMENTE
                if (audioSource != null)
                    audioSource.Stop();

                isTyping = false;
            }
            else
            {
                currentLine++;
                if (currentLine < dialogueData.falas.Count)
                {
                    MostrarFalaAtual();
                }
                else
                {
                    EncerrarDialogo();
                }
            }
        }
    }

    public void IniciarDialogo()
    {
        if (dialogueData == null || dialogueData.falas.Count == 0)
        {
            Debug.LogWarning("[DialogoSistema] DialogueData vazio ao iniciar!");
            return;
        }

        currentLine = 0;
        dialogoAtivo = true;
        aguardandoTrocaCena = false;
        gameObject.SetActive(true);

        MostrarFalaAtual();
    }

    private void MostrarFalaAtual()
    {
        if (dialogueData == null || currentLine < 0 || currentLine >= dialogueData.falas.Count)
            return;

        var falaAtual = dialogueData.falas[currentLine];
        nomeText.text = falaAtual.nomePersonagem;

        StopAllCoroutines();
        StartCoroutine(TypeLine(falaAtual.texto));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        // 🔊 Começa o som de digitação
        if (audioSource != null && letraClip != null)
        {
            audioSource.clip = letraClip;
            audioSource.Play();
        }

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        // 🔊 Para o som quando terminar de digitar
        if (audioSource != null)
            audioSource.Stop();

        isTyping = false;
    }

    private void EncerrarDialogo()
    {
        Debug.Log("[DialogoSistema] Fim do diálogo.");
        dialogoAtivo = false;

        // garante que tudo pare
        if (audioSource != null)
            audioSource.Stop();

        if (mudaCenaAoTerminar)
        {
            aguardandoTrocaCena = true;
            dialogueText.text = "<i>Pressione F para continuar...</i>";
            nomeText.text = "";
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void TrocarCena()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log($"[DialogoSistema] Trocando para cena: {nextSceneName}");
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("[DialogoSistema] Nome da próxima cena não definido!");
        }
    }
}