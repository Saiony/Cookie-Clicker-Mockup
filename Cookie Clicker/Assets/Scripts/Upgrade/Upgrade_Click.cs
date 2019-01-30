using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Click")]
public class Upgrade_Click : Upgrade
{
    public override void EfeitoUpgrade()
    {
        Cookie.cookiesPerClick *= 2; //Dobra a producao de cookies por clique
    }

    public override void TentaDesbloquear()
    {
        if (Cookie.Quantidade >= quantidadeNecessaria)
        {
            InstanciaUpgrade();
            Cookie.Instance.Evt_AumentaCookie -= TentaDesbloquear;//Desinscreve no Evento
        }            
    }

    public override void InscreveEventoDesbloqueio()
    {
        Cookie.Instance.Evt_AumentaCookie += TentaDesbloquear;
    }
}
