using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleGameController : MonoBehaviour
{
    public int erroAchado = 0;
    public int tavaCerto = 0;
    [SerializeField] int tentativas;
    public UnityEvent win7ErrosCondicion;
    public UnityEvent lose7ErrosCondicion;
    public TMP_Text tentativasRestantes;
    public TMP_Text acertosTx;

    void Update()
    {
        acertosTx.text = $"ErrosEncontrados: {erroAchado}";
        tentativasRestantes.text = $"Tentativas Restantes: {tentativas - tavaCerto} ";
        if (erroAchado == 7)
        {
            win7ErrosCondicion.Invoke();
        }
        if (tavaCerto == tentativas)
        { 
            lose7ErrosCondicion.Invoke();
        }
    }
    public void ErroEncontrado()
    {
        bool umaVez = false;
        if (umaVez == false)
        {
            erroAchado++;
            umaVez = true;
        }
        
    }
    public void TavaCerto()
    {
        tavaCerto++;
    }
}
