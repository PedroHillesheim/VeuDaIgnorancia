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
    public void cena2()
    {
        SceneManager.LoadScene("2");
    }
    public void Cena3()
    {
        SceneManager.LoadScene("3");
    }
    public void Cena4()
    {
        SceneManager.LoadScene("4");

    }
    public void Cena5()
    {
        SceneManager.LoadScene("Dialogue 5");

    }

    public void Cena6()
    {
        SceneManager.LoadScene("AndandoAForca");

    }
    public void game1()
    {
        SceneManager.LoadScene("game 1");

    }
    public void game2()
    {
        SceneManager.LoadScene("game 2");

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
