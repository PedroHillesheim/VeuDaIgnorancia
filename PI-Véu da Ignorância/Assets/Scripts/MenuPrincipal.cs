using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }
}