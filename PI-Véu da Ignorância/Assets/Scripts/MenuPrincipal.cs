using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void CreditosVoltar()
    {
        SceneManager.LoadScene("Titulo");
    }
}
