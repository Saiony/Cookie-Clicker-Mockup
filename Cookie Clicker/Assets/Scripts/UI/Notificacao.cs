using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notificacao : MonoBehaviour
{
    public TextMeshProUGUI titulo, descricao;

    public Image imagem;

    public void Fecha()
    {
        Destroy(this.gameObject);
    }

    public void Set(string titulo, string descricao, Sprite imagem)
    {
        this.titulo.text = titulo;
        this.descricao.text = descricao;
        this.imagem.sprite = imagem;
    }
}
