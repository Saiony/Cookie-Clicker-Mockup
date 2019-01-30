using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/CPS")]
public class Achievement_CPS : Achievement
{
    public override void InscreveEvento()
    {
        Cookie.Instance.Evt_AumentaCPS += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (Cookie.Cps >= valorDesbloqueio)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            Cookie.Instance.Evt_AumentaCPS -= this.TentaDesbloquear;
        }
    }
}
