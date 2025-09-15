using UnityEngine;

public class ApareceeDesaparece : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private bool jaApareceu = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        // Come�a invis�vel mas com colisor SEMPRE ativo
        spriteRenderer.enabled = false;
    }

    void OnMouseEnter()
    {
        if (!jaApareceu)
        {
            // Faz aparecer
            spriteRenderer.enabled = true;
            jaApareceu = true;
            Debug.Log("Personagem apareceu!");
            // Avisa o controlador do jogo que encontrou um erro
            //FindObjectOfType<PuzzleGameController>().CliqueEmErro();
        }
    }

}
