using UnityEngine;

public class Erros : MonoBehaviour
{
    public bool increseOneTime = false;
    public int errosans = 0;
    PuzzleGameController puzzleGameController;
    void Start()
    {
        puzzleGameController = FindFirstObjectByType(typeof(PuzzleGameController)) as PuzzleGameController;
    }
    public void OnMouseDown()
    {
        if (increseOneTime == false)
        {
            puzzleGameController.errosans++;
        }
    }
}
