using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Upgrade upgrade;

    public Image imagem;

    private void Start()
    {
        Cookie.Instance.Evt_AumentaCookie += ChecaSePodeComprar;
    }

    public void Display()
    {
        imagem.sprite = upgrade.imagem;
    }

    public void ChecaSePodeComprar()
    {
        if (Cookie.Quantidade >= upgrade.preco)
            this.GetComponent<Button>().interactable = true;
        else
            this.GetComponent<Button>().interactable = false;
    }

    public void CompraUpgrade()
    {
        upgrade.EfeitoUpgrade();
        Cookie.Instance.Evt_AumentaCookie -= ChecaSePodeComprar;
        AllUpgrades.Instance.AddUpgradeDesbloqueado(this.upgrade);//Coloca na lista de upgrades desbloqueados (caso deseje mostrar pro usuario futuramente)
        Destroy(this.gameObject);
    }


#region InformacoesCaixa
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GameObject caixa = CookieUI.Instance.caixaInformativa;

        caixa.GetComponent<CaixaInformativa>().NovasInformacoes(upgrade.nome, upgrade.descricao, upgrade.preco.ToString());//Seta os valores da caixa informativa
        CookieUI.Instance.caixaInformativa.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        CookieUI.Instance.caixaInformativa.SetActive(false);
    }
#endregion
}
