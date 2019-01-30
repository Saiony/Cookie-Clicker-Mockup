using System;
using UnityEngine;

public class Achievement : ScriptableObject
{
    public string nome;
    public string descricao;
    public Sprite imagem;

    public int valorDesbloqueio;

    public event Action Evt_DesbloqueiaAchievement;

    /// <summary>
    /// Inscreve o Achievement no Evento que modifica a variavel referente a complitude do Achievement
    /// </summary>
    public virtual void InscreveEvento() { }
    public virtual void TentaDesbloquear(){ }
    public void ChamaEventoDesbloqueio()
    {
        Evt_DesbloqueiaAchievement?.Invoke();
    }
}
