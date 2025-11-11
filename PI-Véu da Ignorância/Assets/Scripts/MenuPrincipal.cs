using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Som do Clique")]
    public AudioSource clickButton;

    [Header("Nome da Cena para Carregar")]
    public string cenaDestino = "1";

    public void Jogar()
    {
        // Garante que o som exista antes de tentar tocar
        if (clickButton != null)
        {
            clickButton.Play();
            // Inicia a troca de cena após a duração do som
            Invoke(nameof(CarregarCena), clickButton.clip.length);
        }
        else
        {
            Debug.LogWarning("AudioSource não atribuído ao botão!");
            CarregarCena(); // se não houver som, carrega direto
        }
    }

    void CarregarCena()
    {
        SceneManager.LoadScene(cenaDestino);
    }

public void Creditos()
    {
        SceneManager.LoadScene("0 (1)");
    }
    public void CreditosVoltar()
    {
        SceneManager.LoadScene("0");

    }
    public void cena2()
    {
        SceneManager.LoadScene("2");
    }
    public void Cena3()
    {
        SceneManager.LoadScene("falamira");
    }
    public void Cena4()
    {
        SceneManager.LoadScene("3");

    }
    public void Cena5()
    {
        SceneManager.LoadScene("4");

    }

    public void cena6()
    {
        SceneManager.LoadScene("Dialogue 5");

    }
    public void Cena7()
    {
        SceneManager.LoadScene("AndandoAForca");

    }
    public void game1()
    {
        SceneManager.LoadScene("game 2");

    }
    public void game2()
    {
        SceneManager.LoadScene("game");

    }

    public void game3()
    {
        SceneManager.LoadScene("game 3");

    }

    public void finish()
    {
        SceneManager.LoadScene("Finish");

    }
}
