using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/CookiesTotal")]
public class Achievement_CookiesTotal : Achievement
{
    public override void InscreveEvento()
    {
        Cookie.Instance.Evt_AumentaCookie += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (Cookie.cookiesTotal >= valorDesbloqueio) 
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            Cookie.Instance.Evt_AumentaCookie -= this.TentaDesbloquear;
        }
    }
}
