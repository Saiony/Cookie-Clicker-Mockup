using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AchievementDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool bloqueado = true;
    public Achievement achievement;
    public Image imagem;

    public void Desbloquear()
    {
        bloqueado = false;
        imagem.sprite = achievement.imagem;
        GeraNotificacao();
    }

    public void GeraNotificacao()
    {
        GameObject novaNotificacao = Instantiate(CookieUI.Instance.notificacaoPrefab, CookieUI.Instance.notificacaoPanel.transform);
        novaNotificacao.GetComponent<Notificacao>().Set(achievement.nome, achievement.descricao, achievement.imagem);
    }

#region InformacoesCaixa

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GameObject caixa = CookieUI.Instance.caixaInformativa;

        if (!bloqueado)
            caixa.GetComponent<CaixaInformativa>().NovasInformacoes(achievement.nome, achievement.descricao, "");//Seta os valores da caixa informativa
        else
            caixa.GetComponent<CaixaInformativa>().NovasInformacoes("???", "???", "");//Esconde as informacoes de Achievements nao desbloqueados

        CookieUI.Instance.caixaInformativa.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        CookieUI.Instance.caixaInformativa.SetActive(false);
    }

#endregion
}
