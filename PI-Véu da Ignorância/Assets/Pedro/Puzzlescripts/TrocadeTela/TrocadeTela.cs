using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocadeTela : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
