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

    // M�todo para quando clicar em um ERRO (passe o bot�o como par�metro)
    public void CliqueEmErro(Button botaoClicado)
    {
        // Desativa o bot�o para n�o poder clicar de novo
        botaoClicado.interactable = false;
        erroAchado++;
        // Opcional: muda a cor para mostrar que j� foi encontrado
        botaoClicado.image.color = Color.green;
    }

    // M�todo para quando clicar em algo que N�O � um erro
    public void CliqueEmNaoErro()
    {
        tavaCerto++;
    }
}