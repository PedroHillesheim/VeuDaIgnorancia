using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public PuzzlePiece[] puzzlePieces;
    public UnityEvent OnPuzzleCompleted;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        { 
            Destroy(gameObject);
        }
    }

    public void CheckCompletion()
    {
        foreach (var piece in puzzlePieces)
        {
            if (!piece.IsPlaced)
            return;
        }
        Debug.Log("Puzzle completo!");
        OnPuzzleCompleted.Invoke();
    }
}
