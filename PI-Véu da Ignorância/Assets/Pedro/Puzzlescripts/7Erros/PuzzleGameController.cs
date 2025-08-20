using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleGameController : MonoBehaviour
{
    public int errosEncontrados = 0;
    public int tentativasUsadas = 0;
    [SerializeField] int maxTentativas = 10;
    public UnityEvent eventoVitoria;
    public UnityEvent eventoDerrota;
    public TMP_Text textoRestantes;
    public TMP_Text textoAcertos;

    // Lista para guardar todos os bot�es de erro que foram desativados
    private List<Button> botoesDesativados = new List<Button>();
    private List<Color> coresOriginais = new List<Color>();

    void Update()
    {
        textoAcertos.text = $"Erros Encontrados: {errosEncontrados}";
        textoRestantes.text = $"Tentativas Restantes: {maxTentativas - tentativasUsadas}";

        if (errosEncontrados >= 7)
        {
            eventoVitoria.Invoke();
        }
        else if (tentativasUsadas >= maxTentativas)
        {
            eventoDerrota.Invoke();
        }
    }

    // M�todo para quando clicar em um ERRO
    public void CliqueEmErro(Button botaoClicado)
    {
        // S� conta se o bot�o ainda estiver ativo
        if (botaoClicado.interactable)
        {
            // Guarda o bot�o e sua cor original para poder resetar depois
            botoesDesativados.Add(botaoClicado);
            coresOriginais.Add(botaoClicado.image.color);
            // Desativa o bot�o e muda a cor
            botaoClicado.interactable = false;
            botaoClicado.image.color = Color.green;
            errosEncontrados++;
        }
    }

    // M�todo para quando clicar em algo que N�O � um erro
    public void CliqueEmNaoErro()
    {
        tentativasUsadas++;
    }

    // M�TODO NOVO PARA REINICIAR O JOGO
    public void ReiniciarJogo()
    {
        // Reseta as vari�veis
        errosEncontrados = 0;
        tentativasUsadas = 0;
        // Reativa todos os bot�es que foram desativados
        for (int i = 0; i < botoesDesativados.Count; i++)
        {
            if (botoesDesativados[i] != null)
            {
                botoesDesativados[i].interactable = true;
                botoesDesativados[i].image.color = coresOriginais[i];
            }
        }
        // Limpa as listas
        botoesDesativados.Clear();
        coresOriginais.Clear();
        Debug.Log("Jogo reiniciado! Todos os bot�es reativados.");
    }
}