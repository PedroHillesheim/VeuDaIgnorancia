using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocadeTela : MonoBehaviour
{
    PuzzleGameController puzzleGameController;

    private void Update()
    {
        puzzleGameController = FindFirstObjectByType(typeof(PuzzleGameController)) as PuzzleGameController;
    }

    public void Next(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReiniciarJogo()
    {
        puzzleGameController.erroAchado = 0;
        puzzleGameController.tavaCerto = 0;
        //puzzleGameController. (caso necessario)
    }
}
