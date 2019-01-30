using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/AchievementsDesbloqueados")]
public class Achievement_AchievementsDesbloqueados : Achievement
{
    public override void InscreveEvento()
    {
        AllAchievements.Evt_AumentaAchievmentsDesbloqueados += TentaDesbloquear;
    }

    public override void TentaDesbloquear()
    {
        if (AllAchievements.AchievementsDesbloqueados >= valorDesbloqueio)
        {
            AllAchievements.Evt_AumentaAchievmentsDesbloqueados -= this.TentaDesbloquear;
            Debug.Log("Achievement Desbloqueado: " + this.nome);
            ChamaEventoDesbloqueio();            
        }
    }
}
