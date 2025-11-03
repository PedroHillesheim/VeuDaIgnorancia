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
    public void Cena1()
    {
        SceneManager.LoadScene("mira1");
    }
    public void Cena2()
    {
        SceneManager.LoadScene("Dialogue 2");
    }
    public void Cena3()
    {
        SceneManager.LoadScene("Dialogue 3");

    }
}
