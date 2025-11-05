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

    [Header("Outros")]
    public Button botaoFundo; // botão invisível que fica atrás dos erros

    private readonly List<Button> botoesDesativados = new();
    private readonly List<Color> coresOriginais = new();
    private readonly List<GameObject> imagensAtivas = new();

    private bool jogoFinalizado = false;

    void Start()
    {
        // garante que o botão do fundo esteja ativo no início
        if (botaoFundo != null)
            botaoFundo.interactable = true;
    }

    void Update()
    {
        if (textoAcertos != null)
            textoAcertos.text = $"Erros Encontrados: {errosEncontrados}";

        if (textoRestantes != null)
            textoRestantes.text = $"Tentativas Restantes: {maxTentativas - tentativasUsadas}";

        if (!jogoFinalizado)
        {
            if (errosEncontrados >= 7)
            {
                jogoFinalizado = true;
                eventoVitoria?.Invoke();
                DesativarBotaoFundo();
            }
            else if (tentativasUsadas >= maxTentativas)
            {
                jogoFinalizado = true;
                eventoDerrota?.Invoke();
                DesativarBotaoFundo();
            }
        }
    }

    public void CliqueEmErro(Button botaoClicado)
    {
        if (botaoClicado == null || !botaoClicado.interactable || jogoFinalizado) return;

        botoesDesativados.Add(botaoClicado);
        coresOriginais.Add(botaoClicado.image.color);

        botaoClicado.interactable = false;
        botaoClicado.image.color = Color.white;
        errosEncontrados++;

        Transform imagemSobreposta = botaoClicado.transform.Find("ImagemSobreposta");
        if (imagemSobreposta != null)
        {
            imagemSobreposta.gameObject.SetActive(true);
            imagensAtivas.Add(imagemSobreposta.gameObject);
        }
    }

    public void CliqueEmNaoErro(Button botaoClicado)
    {
        if (botaoClicado == null || !botaoClicado.interactable || jogoFinalizado) return;

        tentativasUsadas++;

        botoesDesativados.Add(botaoClicado);
        coresOriginais.Add(botaoClicado.image.color);
        botaoClicado.image.color = new Color(0.85f, 0.85f, 0.85f);

        Transform imagemSobreposta = botaoClicado.transform.Find("ImagemSobreposta");
        if (imagemSobreposta != null)
        {
            imagemSobreposta.gameObject.SetActive(true);
            imagensAtivas.Add(imagemSobreposta.gameObject);
        }
    }

    // novo método pra quando clicar no fundo (botão invisível)
    public void CliqueEmBotaoFundo()
    {
        if (jogoFinalizado) return;

        tentativasUsadas++;
        Debug.Log("Clicou no fundo! Tentativa gasta.");

        // atualiza o texto imediatamente
        if (textoRestantes != null)
            textoRestantes.text = $"Tentativas Restantes: {maxTentativas - tentativasUsadas}";

        if (tentativasUsadas >= maxTentativas)
        {
            jogoFinalizado = true;
            eventoDerrota?.Invoke();
            DesativarBotaoFundo();
        }
    }

    void DesativarBotaoFundo()
    {
        if (botaoFundo != null)
            botaoFundo.interactable = false;
    }

    public void ReiniciarJogo()
    {
        errosEncontrados = 0;
        tentativasUsadas = 0;
        jogoFinalizado = false;

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

        if (botaoFundo != null)
            botaoFundo.interactable = true;

        Debug.Log("Jogo reiniciado com sucesso!");
    }
}
