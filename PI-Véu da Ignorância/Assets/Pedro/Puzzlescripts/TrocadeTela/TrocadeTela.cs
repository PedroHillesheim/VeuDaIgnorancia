using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TrocadeTela : MonoBehaviour
{
    PuzzleGameController puzzleGameController;
    public UnityEvent loseScreen;
    private void Update()
    {
        puzzleGameController = FindFirstObjectByType(typeof(PuzzleGameController)) as PuzzleGameController;
    }

    public void OutraScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
