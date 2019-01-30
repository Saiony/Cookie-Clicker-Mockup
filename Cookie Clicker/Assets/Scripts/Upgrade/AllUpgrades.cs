using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUpgrades : MonoBehaviour
{
    [SerializeField]
    public List<Upgrade> upgradesBloqueados, upgradesDesbloqueados;

    public GameObject upgradePrefab;

    public static AllUpgrades Instance;

    public static int upgradesComprados;

    public static event Action Evt_CompraUpgrade;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        foreach (Upgrade up in upgradesBloqueados)
        {
            up.InscreveEventoDesbloqueio();
        }
            
    }

    //Insere os upgrades desbloqueados em uma lista para futura referência
    public void AddUpgradeDesbloqueado(Upgrade up)
    {
        upgradesDesbloqueados.Add(up);
        upgradesComprados++;
        Evt_CompraUpgrade?.Invoke();
    }
}
