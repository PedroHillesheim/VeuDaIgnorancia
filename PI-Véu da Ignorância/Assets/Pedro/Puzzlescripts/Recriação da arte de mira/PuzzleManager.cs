using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public PuzzlePiece[] puzzlePieces;
    public TMP_Text victoryText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CheckCompletion()
    {
        foreach (var piece in puzzlePieces)
        {
            if (!pieceIsPlaced(piece))
                return;
        }

        // Se chegou aqui, todas as pe�as est�o no lugar
        victoryText.gameObject.SetActive(true);
        victoryText.text = "Parab�ns! Puzzle completo!";
    }

    private bool pieceIsPlaced(PuzzlePiece piece)
    {
        return piece.isPlaced;
    }
}
