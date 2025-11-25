using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TrocadeTela : MonoBehaviour
{
    public void OutraScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
