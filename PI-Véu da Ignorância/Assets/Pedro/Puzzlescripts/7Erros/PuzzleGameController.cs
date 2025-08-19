using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzleGameController : MonoBehaviour
{
    public int erroAchado = 0;
    public int tavaCerto = 0;
    [SerializeField] int maxTentativas = 10;
    public UnityEvent eventoVitoria;
    public UnityEvent eventoDerrota;
    public TMP_Text textoRestantes;
    public TMP_Text textoAcertos;

    void Update()
    {
        textoAcertos.text = $"Erros Encontrados: {erroAchado}";
        textoRestantes.text = $"Tentativas Restantes: {maxTentativas - tavaCerto}";

        if (erroAchado >= 7)
        {
            eventoVitoria.Invoke();
        }
        else if (tavaCerto >= maxTentativas)
        {
            eventoDerrota.Invoke();
        }
    }

    // Método para quando clicar em um ERRO (passe o botão como parâmetro)
    public void CliqueEmErro(Button botaoClicado)
    {
        // Desativa o botão para não poder clicar de novo
        botaoClicado.interactable = false;
        erroAchado++;
        // Opcional: muda a cor para mostrar que já foi encontrado
        botaoClicado.image.color = Color.green;
    }

    // Método para quando clicar em algo que NÃO é um erro
    public void CliqueEmNaoErro()
    {
        tavaCerto++;
    }
}