using TMPro;
using UnityEngine;

public class Codigo : MonoBehaviour
{
    [SerializeField] public int oCodigoEmSi = 3235;
    public int codigoSecreto = 0;
    public int tentativas = 2;
    public TMP_Text textoAviso;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void N1()
    {
        codigoSecreto += 1;
    }
    public void N2()
    {
        codigoSecreto += 2;
    }
    public void N3()
    {
        codigoSecreto += 3;
    }
    public void N4()
    {
        codigoSecreto += 4;
    }
    public void N5()
    {
        codigoSecreto += 5;
    }
    public void N6()
    {
        codigoSecreto += 6;
    }
    public void N7()
    {
        codigoSecreto += 7;
    }
    public void N8()
    {
        codigoSecreto += 8;
    }
    public void N9()
    {
        codigoSecreto += 9;
    }
    public void N0()
    {
        codigoSecreto += 0;
    }
    public void Enter()
    {
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        int codigoLeigth = codigoSecreto.ToString().Length;
        if(codigoLeigth <oCodigoLeigth)
        {
            tentativas--;
            textoAviso.text = "Desculpe o codigo esta incorreto";
        } 
    }
}
