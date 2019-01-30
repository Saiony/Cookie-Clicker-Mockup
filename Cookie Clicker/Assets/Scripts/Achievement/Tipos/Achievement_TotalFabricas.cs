using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/TotalFabricas")]
public class Achievement_TotalFabricas : Achievement
{
    public override void InscreveEvento()
    {
        Fabrica.Instance.Evt_CompraFabrica += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (Fabrica.quantidade >= valorDesbloqueio)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            Fabrica.Instance.Evt_CompraFabrica -= this.TentaDesbloquear;
        }
    }
}
