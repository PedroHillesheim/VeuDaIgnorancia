using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("1");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("0 (1)");
    }
    public void CreditosVoltar()
    {
        SceneManager.LoadScene("0");

    }
    public void Cena1()
    {
        SceneManager.LoadScene("2");
    }
    public void Cena2()
    {
        SceneManager.LoadScene("3");
    }
    public void Cena3()
    {
        SceneManager.LoadScene("4");

    }
    public void Cena4()
    {
        SceneManager.LoadScene("5");

    }
}
