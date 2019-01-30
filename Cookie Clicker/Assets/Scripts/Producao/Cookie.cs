using System;
using UnityEngine;
using UnityEngine.UI;

public class Cookie : MonoBehaviour
{
    public static int Quantidade;
    public static float Cps;
    public static int cookiesPerClick = 1;
    public static int cookiesClickTotal;
    public static int cookiesTotal = 0;

    public event Action Evt_AumentaCookie;
    public event Action Evt_AumentaCPS;
    public event Action Evt_Clica;

    public static Cookie Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("IncrementaPorSegundo", 0, 1);
        PoolSystem.Instance.CreatePool(CookieUI.Instance.cookiesPrefab, 15, CookieUI.Instance.canvas); //Cria Pool de Textos
        PoolSystem.Instance.CreatePool(CookieUI.Instance.cookiesTextPrefab, 15, CookieUI.Instance.canvas); //Cria Pool de Cookies
    }

    private void IncrementaPorSegundo()
    {
        IncrementaCookie((int)Cps);
        Fabrica.cookiesProduzidosTotal += (int)(Fabrica.Instance.Cps * Fabrica.Instance.cpsMultiplier);
    }

    public void IncrementaCookieClick()
    {
        IncrementaCookie(Cookie.cookiesPerClick);
        Cookie.cookiesClickTotal += Cookie.cookiesPerClick;
        Evt_Clica?.Invoke();

        CookieAnimacao(); //Cookies jogados e texto subindo
    }

    public void IncrementaCookie(int value)
    {
        Cookie.Quantidade += value;
        Cookie.cookiesTotal += value;
        AtualizaCookiesUI();
        //Chama o evento de Aumento de Cookie para chamar os métodos que dependem dele
        Evt_AumentaCookie?.Invoke();
    }

    public void AtualizaCookiesUI()
    {
        CookieUI.Instance.cookiesText.text = Cookie.Quantidade.ToString() + " cookies";
        CookieUI.Instance.cpsText.text = "per second: " + Cookie.Cps.ToString();
    }

    public void AtualizaCps()
    {
        Cookie.Cps = (Fabrica.Instance.Cps*Fabrica.Instance.cpsMultiplier);
        Evt_AumentaCPS?.Invoke();
    }

    public void CookieAnimacao()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject cookieJogado = PoolSystem.Instance.ReuseObject(CookieUI.Instance.cookiesPrefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity, CookieUI.Instance.canvas);
        cookieJogado.GetComponent<JogaCookie>().Inicializa();

        GameObject textoSubido = PoolSystem.Instance.ReuseObject(CookieUI.Instance.cookiesTextPrefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity, CookieUI.Instance.canvas);
        textoSubido.GetComponent<SobeTexto>().Inicializa();
    }
}
