using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAchievements : MonoBehaviour
{
    [SerializeField]
    private GameObject achievementPrefab;
    public List<Achievement> achiev_cps;
    public List<Achievement> achiev_cookiesTotal;
    public List<Achievement> achiev_fabricasTotal;
    public List<Achievement> achiev_fabricasCPS;
    public List<Achievement> achiev_cookiesClickTotal;
    public List<Achievement> achiev_cookiesFabricaTotal;
    public List<Achievement> achiev_cookiesOneClick;
    public List<Achievement> achiev_upgadesComprados;
    public List<Achievement> achiev_achievementsDesbloqueados;
    public List<Achievement> achiev_multiTarefa;


    public static event Action Evt_AumentaAchievmentsDesbloqueados;
    public static int AchievementsDesbloqueados = 0;

    private void Start()
    {
        InstanciaAchievements(achiev_cps);
        InstanciaAchievements(achiev_cookiesTotal);
        InstanciaAchievements(achiev_fabricasTotal);
        InstanciaAchievements(achiev_fabricasCPS);
        InstanciaAchievements(achiev_cookiesClickTotal);
        InstanciaAchievements(achiev_cookiesFabricaTotal);
        InstanciaAchievements(achiev_cookiesOneClick);
        InstanciaAchievements(achiev_upgadesComprados);
        InstanciaAchievements(achiev_achievementsDesbloqueados);
        InstanciaAchievements(achiev_multiTarefa);

    }

    private void InstanciaAchievements(List<Achievement> listaAchievements)
    {
        foreach(Achievement achiev in listaAchievements)
        {
            GameObject novoAchiev = Instantiate(achievementPrefab, CookieUI.Instance.achievementPanel.transform);
            AchievementDisplay achievDisplay = novoAchiev.GetComponent<AchievementDisplay>();
            achievDisplay.achievement = achiev;

            //Inscreve o achievement nos eventos de desbloqueio.
            achievDisplay.achievement.InscreveEvento();
            achievDisplay.achievement.Evt_DesbloqueiaAchievement += achievDisplay.Desbloquear;
            achievDisplay.achievement.Evt_DesbloqueiaAchievement += AumentaAchievementsDesbloqueados;
        }
    }

    public void AumentaAchievementsDesbloqueados()
    {
        AllAchievements.AchievementsDesbloqueados++;
        Evt_AumentaAchievmentsDesbloqueados?.Invoke();
    }
}
