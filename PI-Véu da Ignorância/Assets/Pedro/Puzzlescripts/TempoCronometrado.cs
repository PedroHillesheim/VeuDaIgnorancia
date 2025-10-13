using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TempoCronometrado : MonoBehaviour
{
    public float tempoInicial = 60f;
    private float tempoRestante;
    public UnityEvent loseScreen;
    private bool isRunning = true;
    public TMP_Text tempoAmostra;

    void Start()
    {
        tempoRestante = tempoInicial;
        tempoAmostra.text = " ";
    }

    void Update()
    {
        tempoAmostra.text = tempoRestante.ToString();
        if (!isRunning)
            return;

        tempoRestante -= Time.deltaTime;

        if (tempoRestante <= 0f)
        {
            tempoRestante = 0f;
            isRunning = false;
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        loseScreen?.Invoke();
    }
    public string GetTempoFormatado()
    {
        int minutos = Mathf.FloorToInt(tempoRestante / 60);
        int segundos = Mathf.FloorToInt(tempoRestante % 60);
        return $"{minutos:00}:{segundos:00}";
    }
    public void ReiniciarTimer()
    {
        tempoRestante = tempoInicial;
        isRunning = true;
    }
}
