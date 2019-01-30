using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/UpgradesComprados")]
public class Achievement_UpgradesDesbloqueados : Achievement
{
    public override void InscreveEvento()
    {
        AllUpgrades.Evt_CompraUpgrade += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (AllUpgrades.upgradesComprados >= valorDesbloqueio)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();
            AllUpgrades.Evt_CompraUpgrade -= this.TentaDesbloquear;
        }
    }
}
