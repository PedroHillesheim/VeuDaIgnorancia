using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleGameController : MonoBehaviour
{
    public int errorsans = 0;
    public int tavaCerto = 0;
    [SerializeField] int tentativas;
    public UnityEvent win7ErrosCondicion;
    public UnityEvent lose7ErrosCondicion;
    public TMP_Text tentativasRestantes;
    public TMP_Text acertosTx;

    void Update()
    {
        acertosTx.text = $"ErrosEncontraso: {errorsans}";
        tentativasRestantes.text = $"Tentativas Restantes: {tavaCerto -= tentativas}";
        if (errorsans == 7)
        {
            win7ErrosCondicion.Invoke();
        }
        if (tavaCerto == tentativas)
        {
            lose7ErrosCondicion.Invoke();
        }

    }
}
