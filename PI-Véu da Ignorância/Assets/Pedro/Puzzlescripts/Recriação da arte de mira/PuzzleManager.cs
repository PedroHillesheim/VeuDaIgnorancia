using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [Header("Peças do Puzzle")]
    public PuzzlePiece[] puzzlePieces;

    [Header("Contadores")]
    [Tooltip("Número máximo de peças no puzzle")]
    public int maxPieces = 8;

    [Tooltip("Número de peças já colocadas corretamente")]
    public int placedPieces = 0;

    [Header("Tela de Vitória")]
    [Tooltip("Painel que aparece quando o puzzle é completado")]
    public GameObject victoryPanel;

    [Tooltip("Evento disparado ao completar o puzzle")]
    public UnityEvent OnPuzzleCompleted;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        // Se o array de peças tiver mais peças que o valor padrão, ajusta automaticamente
        if (puzzlePieces != null && puzzlePieces.Length > 0)
            maxPieces = puzzlePieces.Length;
    }

    public void CheckCompletion()
    {
        // Atualiza a contagem de peças colocadas
        placedPieces = 0;

        foreach (var piece in puzzlePieces)
        {
            if (piece.IsPlaced)
                placedPieces++;
        }

        // Exibe no console o progresso (para debug)
        Debug.Log($"Peças colocadas: {placedPieces}/{maxPieces}");

        // ✅ Condição de vitória (como você pediu)
        if (placedPieces >= maxPieces)
        {
            Debug.Log("🎉 Puzzle completo!");
            ShowVictoryScreen();
            OnPuzzleCompleted.Invoke();
        }
    }

    private void ShowVictoryScreen()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(true);
    }
}
