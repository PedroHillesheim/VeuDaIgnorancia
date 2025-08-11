using UnityEngine;

public class ErrosCertos : MonoBehaviour
{
    PuzzleGameController puzzleGameController;
    bool oneTimes = false;
    void Start()
    {
        puzzleGameController = FindFirstObjectByType(typeof(PuzzleGameController)) as PuzzleGameController;
    }
    public void OnMouseDown()
    {
        if (oneTimes == false)
        {
            puzzleGameController.erroAchado++;
            oneTimes = true;
        }
    }
}
