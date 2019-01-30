using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/FabricaCPS")]
public class Achievement_FabricaCps : Achievement
{
    public override void InscreveEvento()
    {
        Fabrica.Instance.Evt_AumentaCps += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (Fabrica.Instance.Cps >= valorDesbloqueio)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            Fabrica.Instance.Evt_AumentaCps -= this.TentaDesbloquear;
        }
    }
}
