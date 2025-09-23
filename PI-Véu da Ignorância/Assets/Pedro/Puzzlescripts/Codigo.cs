using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Codigo : MonoBehaviour
{
    public int tentativas = 0;
    public GameObject painelCodigo;
    public TMP_Text textoCodigoDigitado;
    public TMP_Text textoResultado;
    public UnityEvent winSreen;
    public GameObject loseScreen;
    public TMP_Text textoTentetivas;

    public string codigoCorreto = "1234";
    private string codigoAtual = "";

    public int maxDigitos = 4;

    public Transform player;
    public Transform areaCodigo;
    public float distanciaMaxima = 3f;

    //public Transform porta;
    //public Vector3 posicaoAberta;   
    //public float velocidadePorta = 2f;

    //private Vector3 posicaoFechada;
    //private bool portaAberta = false;

    void Start()
    {
        painelCodigo.SetActive(false);
       // posicaoFechada = porta.position;
        textoResultado.text = " ";
        textoCodigoDigitado.text = " ";
    }

    void Update()
    {
        textoTentetivas.text = tentativas.ToString();
        float distancia = Vector3.Distance(player.position, areaCodigo.position);

        if (distancia <= distanciaMaxima)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!painelCodigo.activeSelf)
                {
                    painelCodigo.SetActive(true);
                    textoResultado.text = "";
                    LimparCodigo();
                }
            }
        }
        else
        {
            if (painelCodigo.activeSelf)
            {
                painelCodigo.SetActive(false);
                LimparCodigo();
                textoResultado.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && painelCodigo.activeSelf)
        {
            painelCodigo.SetActive(false);
            LimparCodigo();
            textoResultado.text = "";
        }

        //if (portaAberta)
        //{
          //  porta.position = Vector3.MoveTowards(porta.position, posicaoAberta, velocidadePorta * Time.deltaTime);
        //}
        //else
        //{
          
          //  porta.position = Vector3.MoveTowards(porta.position, posicaoFechada, velocidadePorta * Time.deltaTime);
        //}
        if (tentativas >= 3)
        {
            loseScreen.SetActive(true);
        }
    }

    public void InserirNumero(string numero)
    {
        if (codigoAtual.Length >= maxDigitos)
            return;

        codigoAtual += numero;
        AtualizarTextoCodigo();
    }

    public void VerificarCodigo()
    {
        if (codigoAtual == codigoCorreto)
        {
            textoResultado.text = "Parabéns! Você ganhou!";
            textoResultado.color = Color.green;
            winSreen.Invoke();
            painelCodigo.SetActive(false);
        }
        else
        {
            textoResultado.text = "Código incorreto.";
            textoResultado.color = Color.red;
            tentativas++;
        }

        LimparCodigo();
    }

    public void LimparCodigo()
    {
        codigoAtual = "";
        AtualizarTextoCodigo();
    }

    void AtualizarTextoCodigo()
    {
        textoCodigoDigitado.text = codigoAtual;
    }
    public void ResetButton()
    {
        loseScreen.SetActive(false);
    }

    //void AbrirPorta()
    //{
        //portaAberta = true;
    //}/

    
    //public void FecharPorta()
    //{
        //portaAberta = false;
    //}
}
