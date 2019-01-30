using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Fabrica")]
public class Upgrade_Fabrica : Upgrade
{
    public override void EfeitoUpgrade()
    {
        Fabrica.Instance.IncrementaMultiplicadorCps(2); //Dobra a producao das fabricas
        Cookie.Instance.AtualizaCps();
        Cookie.Instance.AtualizaCookiesUI();
    }

    public override void TentaDesbloquear()
    {
        if (Fabrica.quantidade >= quantidadeNecessaria)
        {
            InstanciaUpgrade();
            Fabrica.Instance.Evt_CompraFabrica -= TentaDesbloquear;//Desinscreve no Evento
        }

    }

    public override void InscreveEventoDesbloqueio()
    {
        Fabrica.Instance.Evt_CompraFabrica += TentaDesbloquear;
    }

}
