using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Codigo : MonoBehaviour
{
    [SerializeField] public int oCodigoEmSi = 3235;
    public int codigoSecreto = 0000;
    public int tentativas = 2;
    public TMP_Text textoAviso;
    public UnityEvent winScreen;
    public UnityEvent loseScreen;
    public TMP_Text textoDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (tentativas == 0)
        {
            loseScreen.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        textoDisplay.text = $"{codigoSecreto}";
    }
    public void N1()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 1;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }

    }
    public void N2()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 2;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N3()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 3;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N4()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 4;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N5()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 5;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N6()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 6;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N7()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 7;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N8()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 8;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N9()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 9;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void N0()
    {
        int secretoLeigth = codigoSecreto.ToString().Length;
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        if (secretoLeigth <= oCodigoLeigth)
        {
            codigoSecreto += 0;
        }
        else
        {
            textoAviso.text = "Desculpe o maximo é 4 caracteres";
        }
    }
    public void Enter()
    {
        int oCodigoLeigth = oCodigoEmSi.ToString().Length;
        int codigoLeigth = codigoSecreto.ToString().Length;
        if(codigoLeigth < oCodigoLeigth)
        {
            tentativas--;
            textoAviso.text = "Desculpe o codigo tem mais caracteres";
            textoAviso.color = Color.red;
        } 
        else if (codigoLeigth > oCodigoLeigth)
        {
            tentativas--;
            textoAviso.text = "Desculpe o codigo tem menos caracteres";
        }
        else if(codigoSecreto == oCodigoEmSi)
        {
            textoAviso.text = "Correto";
            winScreen.Invoke();
        }
        else
        {
            tentativas--;
            textoAviso.text = "Desculpe o codigo está incorreto";
        }
    }
}
