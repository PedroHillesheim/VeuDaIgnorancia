using UnityEngine;  // Importa classes do Unity
using UnityEngine.SceneManagement;  // Para carregar scenes
using System.Collections;  // Para coroutines

public class JumpscareBasico : MonoBehaviour  // Classe que herda de MonoBehaviour (padrão no Unity)
{
    // Variáveis públicas (aparecem no Inspector)
    public GameObject objetoSusto;  // O objeto a ativar (ex.: uma imagem ou prefab)
    public AudioSource somSusto;    // O som a tocar (adicione um AudioSource)
    public float tempoSusto = 2f;   // Tempo do susto em segundos
    public string proximaScene = "MainScene";  // Nome da scene a carregar depois

    void Start()  // Método que roda uma vez quando o script inicia
    {
        // Ativar o objeto de susto (se existir)
        if (objetoSusto != null)
        {
            objetoSusto.SetActive(true);  // Liga o objeto
        }

        // Tocar o som (se existir)
        if (somSusto != null)
        {
            somSusto.Play();  // Reproduz o áudio
        }

        // Iniciar a coroutine para esperar e carregar a próxima scene
        StartCoroutine(EsperarECarregar());
    }

    // Coroutine: Pausa o código sem parar o jogo
    IEnumerator EsperarECarregar()
    {
        // Esperar o tempo definido
        yield return new WaitForSeconds(tempoSusto);  // Pausa por 'tempoSusto' segundos

        // Carregar a próxima scene
        SceneManager.LoadScene(proximaScene);
    }
}



