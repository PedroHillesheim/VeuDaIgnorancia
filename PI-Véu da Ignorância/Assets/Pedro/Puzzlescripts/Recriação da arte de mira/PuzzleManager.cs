using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }
    public int totalPieces = 0;
    public int placedPieces = 0;
    [Header("Tela de Vitória")]
    public GameObject victoryScreen;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (victoryScreen != null)
            victoryScreen.SetActive(false);
    }

    public void CheckCompletion()
    {
        if (placedPieces >= totalPieces)
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
