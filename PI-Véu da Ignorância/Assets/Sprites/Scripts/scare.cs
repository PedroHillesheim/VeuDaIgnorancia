using UnityEngine;
using UnityEngine.SceneManagement;

public class ScareSceneLoaderJunior : MonoBehaviour
{
    
    public string nextSceneName = "6";
    
    public float scareDuration = 2.0f;

    private float timer;

    private bool hasLoadedNextScene = false;
    void Start()
    {

        timer = 0f;
    }

    void Update()
    {

        if (!hasLoadedNextScene)
        {

            timer += Time.deltaTime;


            if (timer >= scareDuration)
            {
                hasLoadedNextScene = true;


                SceneManager.LoadScene(6);
            }
        }
    }
}