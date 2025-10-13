using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Dialogue");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }
    public void CreditosVoltar()
    {
        SceneManager.LoadScene("Titulo");

    }
}
