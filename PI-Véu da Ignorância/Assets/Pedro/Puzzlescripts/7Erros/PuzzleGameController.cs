using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleGameController : MonoBehaviour
{
    [Header("Status do jogo")]
    public int errosEncontrados = 0;
    public int tentativasUsadas = 0;
    [SerializeField] int maxTentativas = 10;

    [Header("Eventos")]
    public UnityEvent eventoVitoria;
    public UnityEvent eventoDerrota;

    [Header("Referências UI")]
    public TMP_Text textoRestantes;
    public TMP_Text textoAcertos;

    private readonly List<Button> botoesDesativados = new();
    private readonly List<Color> coresOriginais = new();
    private readonly List<GameObject> imagensAtivas = new();

    void Update()
    {
        if (textoAcertos != null)
            textoAcertos.text = $"Erros Encontrados: {errosEncontrados}";

        if (textoRestantes != null)
            textoRestantes.text = $"Tentativas Restantes: {maxTentativas - tentativasUsadas}";

        if (errosEncontrados >= 7)
            eventoVitoria?.Invoke();
        else if (tentativasUsadas >= maxTentativas)
            eventoDerrota?.Invoke();
    }

    public void CliqueEmErro(Button botaoClicado)
    {
        if (botaoClicado == null || !botaoClicado.interactable) return;

        botoesDesativados.Add(botaoClicado);
        coresOriginais.Add(botaoClicado.image.color);

        botaoClicado.interactable = false;
        botaoClicado.image.color = Color.white;
        errosEncontrados++;

        // 🔍 Encontra o filho chamado "ImagemSobreposta"
        Transform imagemSobreposta = botaoClicado.transform.Find("ImagemSobreposta");
        if (imagemSobreposta != null)
        {
            imagemSobreposta.gameObject.SetActive(true);
            imagensAtivas.Add(imagemSobreposta.gameObject);
        }
        else
        {
            Debug.LogWarning($"Nenhum filho chamado 'ImagemSobreposta' encontrado em {botaoClicado.name}");
        }
    }

    public void CliqueEmNaoErro()
    {
        tentativasUsadas++;
    }

    public void ReiniciarJogo()
    {
        errosEncontrados = 0;
        tentativasUsadas = 0;

        for (int i = 0; i < botoesDesativados.Count; i++)
        {
            if (botoesDesativados[i] != null)
            {
                botoesDesativados[i].interactable = true;
                botoesDesativados[i].image.color = coresOriginais[i];
            }
        }

        foreach (var img in imagensAtivas)
        {
            if (img != null)
                img.SetActive(false);
        }

        botoesDesativados.Clear();
        coresOriginais.Clear();
        imagensAtivas.Clear();

        Debug.Log("🔁 Jogo reiniciado com sucesso!");
    }
}