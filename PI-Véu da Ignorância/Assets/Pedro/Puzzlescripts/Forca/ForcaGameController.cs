using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ForcaGameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textPalavraEscondida, textLetrasErradas;
    [SerializeField] string palavraSecreta;
    [SerializeField] UnityEvent winScreen;
    [SerializeField] UnityEvent loseScreen;
    char[] palavraEscondida;
    string letrasErradas = "";
    int tentativasRestantes = 6;
    bool verificacaoDeDerrota = false;
    public bool pareDeAVerifica��o = false;

    void Start()
    {
        palavraSecreta = palavraSecreta.ToUpper();
        ReiniciarJogo();
    }

    void Update()
    {
        for (char c = 'A'; c <= 'Z'; c++)
        {
            if (pareDeAVerifica��o == true)
            {
                break;
            }
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
        if (letrasErradas.Contains(letra.ToString()) || new string(palavraEscondida).Contains(letra))
        {
            return;
        }

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
        textPalavraEscondida.text = new string(palavraEscondida);
        textLetrasErradas.text = "Erros: " + letrasErradas + " | Tentativas: " + tentativasRestantes;
        WinScreen();
    }

    public void ReiniciarJogo()
    {
        letrasErradas = "";
        tentativasRestantes = 6;
        palavraEscondida = new string('_', palavraSecreta.Length).ToCharArray();
        if (verificacaoDeDerrota == true)
        {
            loseScreen.Invoke();
            verificacaoDeDerrota = false;
        }
        verificacaoDeDerrota = false;
        pareDeAVerifica��o = false;
        AtualizarUI();
    }

    public void WinScreen()
    {
        if (new string(palavraEscondida) == palavraSecreta)
        {
            winScreen.Invoke();
            pareDeAVerifica��o = true;
        }
    }

    public void LoseScreen()
    {
        if (tentativasRestantes <= 0)
        {
            loseScreen.Invoke();
            verificacaoDeDerrota = true;
            pareDeAVerifica��o = true;
        }
    }
}