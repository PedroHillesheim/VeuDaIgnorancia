using UnityEngine;

public class ErrosCertos : MonoBehaviour
{
    public bool increseOneTime = false;
    PuzzleGameController puzzleGameController;
    void Start()
    {
        puzzleGameController = FindFirstObjectByType(typeof(PuzzleGameController)) as PuzzleGameController;
    }
    public void OnMouseDown()
    {
        if (increseOneTime == false)
        {
            puzzleGameController.errorsans++;
        }
    }
}
