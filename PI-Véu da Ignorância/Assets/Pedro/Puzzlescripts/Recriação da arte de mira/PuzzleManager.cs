using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    public int totalPieces = 0;       // Total de peças do quebra-cabeça
    public int placedPieces = 0;      // Quantas já foram colocadas

    [Header("Tela de Vitória")]
    public GameObject victoryScreen;  // UI ou painel a ser exibido

    private void Awake()
    {
        // Define a instância única
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Certifica que a tela de vitória começa oculta
        if (victoryScreen != null)
            victoryScreen.SetActive(false);
    }

    public void CheckCompletion()
    {
        // Verifica se todas as peças foram colocadas
        if (placedPieces >= totalPieces)
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        Debug.Log("🎉 Quebra-cabeça completo!");
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Nenhum objeto de tela de vitória atribuído!");
        }

        // Opcional: mudar de cena automaticamente
        // SceneManager.LoadScene("CenaDeVitoria");
    }
}
