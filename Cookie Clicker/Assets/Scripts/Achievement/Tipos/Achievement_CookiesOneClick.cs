using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/CookiesOneClick")]
public class Achievement_CookiesOneClick : Achievement
{
    public override void InscreveEvento()
    {
        Cookie.Instance.Evt_Clica += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (Cookie.cookiesPerClick >= valorDesbloqueio)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            Cookie.Instance.Evt_Clica -= this.TentaDesbloquear;
        }
    }
}
