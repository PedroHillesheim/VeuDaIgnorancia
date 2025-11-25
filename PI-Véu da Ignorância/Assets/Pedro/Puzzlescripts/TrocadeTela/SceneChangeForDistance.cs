using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeForDistance : MonoBehaviour
{
    public string sceneName = "NomeDaNovaCena"; 
    public float triggerDistance = 3f; 
    public Transform player; 

    private bool isChanging = false;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance && !isChanging)
        {
            isChanging = true;
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
