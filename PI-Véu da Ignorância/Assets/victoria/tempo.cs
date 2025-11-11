using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Configuração de Tempo")]
    public float delayTime = 5f; // tempo em segundos até a troca

    [Header("Cena a ser carregada")]
    public string sceneName = "Fase1"; // nome da cena que será carregada

    void Start()
    {
        // Chama o método que carrega a cena depois do tempo definido
        Invoke(nameof(LoadSceneAfterDelay), delayTime);
    }

    void LoadSceneAfterDelay()
    {
        SceneManager.LoadScene(sceneName);
    }
}