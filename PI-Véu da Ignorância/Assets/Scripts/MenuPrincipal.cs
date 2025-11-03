using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Dialogo");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }
    public void CreditosVoltar()
    {
        SceneManager.LoadScene("Titulo");

    }
    public void LL()
    {
        SceneManager.LoadScene("mira1");
    }
    public void AAA()
    {
        SceneManager.LoadScene("Dialogue 2");
    }
    public void NN()
    {
        SceneManager.LoadScene("Dialogue 3");

    }
}
