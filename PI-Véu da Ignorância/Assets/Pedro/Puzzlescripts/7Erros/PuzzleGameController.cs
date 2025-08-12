using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleGameController : MonoBehaviour
{
    public int erroAchado = 0;
    public int tavaCerto = 0;
    bool apenasUmaVez = true;
    [SerializeField] int tentativas;
    public UnityEvent win7ErrosCondicion;
    public UnityEvent lose7ErrosCondicion;
    public TMP_Text tentativasRestantes;
    public TMP_Text acertosTx;

    void Update()
    {
        acertosTx.text = $"ErrosEncontraso: {erroAchado}";
        tentativasRestantes.text = $"Tentativas Restantes: {tentativas - tavaCerto}";
        if (erroAchado == 7)
        {
            win7ErrosCondicion.Invoke();
        }
        if (tavaCerto == tentativas)
        {
            lose7ErrosCondicion.Invoke();
        }
    }
    public void OnMouseDown()
    {
        if(apenasUmaVez == true)
        {
            erroAchado++;
            apenasUmaVez = false;
        }
    }
}
