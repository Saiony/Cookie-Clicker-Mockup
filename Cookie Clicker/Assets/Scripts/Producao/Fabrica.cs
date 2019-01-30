using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Fabrica : MonoBehaviour, IConstrucao, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI precoTxt, quantidadeTxt;
    [SerializeField]
    private Button btnFabrica;

    public float Cps;
    public float cpsMultiplier = 1;
    public static int quantidade;
    public int precoProxima = 5;
    public static int cookiesProduzidosTotal;
    public float aumentoPreço = 1.15f;//Aumento de 15%

    public static Fabrica Instance;

    private string nome = "Fabrica";
    private string descricao = "Produces large quantities of cookies.";

    public event Action Evt_CompraFabrica;
    public event Action Evt_AumentaCps;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        Cookie.Instance.Evt_AumentaCookie += ChecaSePodeComprar;
    }

    public void CompraConstrucao()
    {
        Cookie.Instance.IncrementaCookie(-precoProxima);
        IncrementaCps(5);
        AumentaPreço();
        AumentaQtd();
        Cookie.Instance.AtualizaCps();

        AtualizaUI();
        Cookie.Instance.AtualizaCookiesUI();
        ChecaSePodeComprar();
    }

    public void IncrementaCps(int value)
    {
        this.Cps += value;
        Evt_AumentaCps?.Invoke();
    }

    public void IncrementaMultiplicadorCps(int value)
    {
        this.cpsMultiplier *= value;
        Evt_AumentaCps?.Invoke();
    }

    public void AumentaPreço()
    {
        float aux = precoProxima * aumentoPreço;
        this.precoProxima = (int)Mathf.Round(aux);
    }

    public void AumentaQtd()
    {
        Fabrica.quantidade++;
        Evt_CompraFabrica?.Invoke(); //Chama Evento de Compra de Fabrica
    }

    public void AtualizaUI()
    {
        precoTxt.text = precoProxima.ToString();
        quantidadeTxt.text = quantidade.ToString();
    }

    public void ChecaSePodeComprar()
    {
        if (Cookie.Quantidade >= precoProxima)
            btnFabrica.interactable = true;
        else
            btnFabrica.interactable = false;
           
    }

#region InformacoesCaixa
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GameObject caixa = CookieUI.Instance.caixaInformativa;

        caixa.GetComponent<CaixaInformativa>().NovasInformacoes(nome, descricao, precoProxima.ToString());//Seta os valores da caixa informativa
        caixa.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        CookieUI.Instance.caixaInformativa.SetActive(false);
    }
#endregion
}
