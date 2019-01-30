using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/MultiTarefa")]
public class Achievement_MultiTarefa : Achievement
{
    public int quantidadeFabricas;

    public override void InscreveEvento()
    {
        AllUpgrades.Evt_CompraUpgrade += TentaDesbloquear;
        Fabrica.Instance.Evt_CompraFabrica += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (AllUpgrades.upgradesComprados >= valorDesbloqueio && Fabrica.quantidade >= quantidadeFabricas)
        {
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();

            AllUpgrades.Evt_CompraUpgrade -= TentaDesbloquear;
            Fabrica.Instance.Evt_CompraFabrica -= TentaDesbloquear;
        }
    }
}
