using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/CookiesClickTotal")]
public class Achievement_CookiesClickTotal : Achievement
{
    public override void InscreveEvento()
    {
        Cookie.Instance.Evt_AumentaCookie += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (Cookie.cookiesClickTotal >= valorDesbloqueio)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            Cookie.Instance.Evt_AumentaCookie -= this.TentaDesbloquear;
        }
    }
}
