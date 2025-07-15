using UnityEngine;

public class TavaCerto : MonoBehaviour
{
    PuzzleGameController puzzleGameController;
    void Start()
    {
        puzzleGameController = FindFirstObjectByType(typeof(PuzzleGameController)) as PuzzleGameController;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        puzzleGameController.tavaCerto++;
    }
}
