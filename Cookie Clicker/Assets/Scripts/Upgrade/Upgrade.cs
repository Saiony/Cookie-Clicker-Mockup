using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string nome;
    public string descricao;

    public Sprite imagem;

    public int quantidadeNecessaria;
    public int preco;

    public virtual void InscreveEventoDesbloqueio() { }
    public virtual void TentaDesbloquear() {}
    public virtual void EfeitoUpgrade() { }
    public virtual void ChecaSePodeComprar() { }

    public void InstanciaUpgrade()
    {
        GameObject novoUpgrade = Instantiate(AllUpgrades.Instance.upgradePrefab, CookieUI.Instance.upgradePanel.transform);//Desbloqueia o upgrade no painel de upgrades

        //Insere e mostra as informacoes do upgrade
        novoUpgrade.GetComponent<UpgradeDisplay>().upgrade = this;
        novoUpgrade.GetComponent<UpgradeDisplay>().Display();

        Debug.Log("Upgrade desbloqueado: " + this.nome);

        AllUpgrades.Instance.upgradesBloqueados.Remove(this);//Remove da lista de upgrades Bloqueados
        AllUpgrades.Instance.upgradesDesbloqueados.Add(this);//Adiciona na lista de Upgrades Desbloqueados
    }
}
