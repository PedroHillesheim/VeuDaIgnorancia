using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ForcaGameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textPalavraEscondida, textLetrasErradas;
    [SerializeField] string palavraSecreta;
    [SerializeField] UnityEvent winScreen;
    [SerializeField] GameObject loseScreen;

    char[] palavraEscondida;
    string letrasErradas = "";
    int tentativasRestantes = 6;
    public bool pareDeAVerificacao = false;

    void Start()
    {
        palavraSecreta = palavraSecreta.ToUpper();
        ReiniciarJogo();
    }

    void Update()
    {
        for (char c = 'A'; c <= 'Z'; c++)
        {
            if (pareDeAVerificacao)
                break;

            KeyCode key = KeyCode.A + (c - 'A');
            if (Input.GetKeyDown(key))
            {
                ProcessarLetra(c);
                break;
            }
        }
    }

    void ProcessarLetra(char letra)
    {
        // ignora letras já tentadas
        if (letrasErradas.Contains(letra.ToString()) || new string(palavraEscondida).Contains(letra))
            return;

        bool acertou = false;

        for (int i = 0; i < palavraSecreta.Length; i++)
        {
            if (palavraSecreta[i] == letra)
            {
                palavraEscondida[i] = letra;
                acertou = true;
            }
        }

        if (!acertou)
        {
            letrasErradas += letra + " ";
            tentativasRestantes--;
            LoseScreen();
        }
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (textPalavraEscondida != null)
            textPalavraEscondida.text = new string(palavraEscondida);
        if (textLetrasErradas != null)
            textLetrasErradas.text = "Erros: " + letrasErradas + " | Tentativas: " + tentativasRestantes;

        WinScreen();
    }

    public void ReiniciarJogo()
    {
        Debug.Log("ReiniciarJogo chamado");

        // Se loseScreen não foi atribuído, tenta localizar por nome (apenas como fallback)
        if (loseScreen == null)
        {
            Debug.LogWarning("loseScreen não atribuído no Inspector. Tentando localizar objeto 'LoseScreen' na cena...");
            GameObject encontrado = GameObject.Find("LoseScreen"); // nome exemplo, ajuste se necessário
            if (encontrado != null) loseScreen = encontrado;
        }

        // De volta ao estado inicial
        letrasErradas = "";
        tentativasRestantes = 6;
        palavraSecreta = (palavraSecreta ?? "").ToUpper();
        palavraSecreta = palavraSecreta.Trim(); // remove espaços extras
        if (palavraSecreta.Length == 0)
        {
            Debug.LogWarning("palavraSecreta está vazia!");
            palavraSecreta = "TESTE";
        }

        palavraEscondida = new string('_', palavraSecreta.Length).ToCharArray();

        // Garantir que o painel de derrota seja fechado
        if (loseScreen != null)
        {
            loseScreen.SetActive(false);
        }
        else
        {
            Debug.LogError("loseScreen continua nulo após tentativa de localizar. Configure no Inspector ou renomeie o objeto para 'LoseScreen' se quiser fallback.");
        }

        // Se você tiver um painel de vitória separado, feche-o também aqui. (Exemplo:)
        // if (winPanel != null) winPanel.SetActive(false);

        pareDeAVerificacao = false;

        // Reset qualquer outro estado do jogo aqui (ex: scores, peças, etc)

        AtualizarUI();
    }

    public void WinScreen()
    {
        if (new string(palavraEscondida) == palavraSecreta)
        {
            winScreen?.Invoke();
            pareDeAVerificacao = true;
        }
    }

    public void LoseScreen()
    {
        if (tentativasRestantes <= 0)
        {
            if (loseScreen != null) loseScreen.SetActive(true);
            else Debug.LogError("LoseScreen deveria aparecer, mas loseScreen é nulo.");
            pareDeAVerificacao = true;
        }
    }

    // Método público seguro para o botão do painel de "perdeu"
    public void BotaoReiniciar()
    {
        Debug.Log("BotaoReiniciar pressionado");
        ReiniciarJogo();
    }

    // Alternativa: recarregar a cena (use se preferir garantir reset total)
    public void BotaoRecarregarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}