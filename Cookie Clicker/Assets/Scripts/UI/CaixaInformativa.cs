using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaixaInformativa : MonoBehaviour
{
    public Transform titulo, descricao, preco;

    private void FixedUpdate()
    {
        SegueMouse();
    }

    private void SegueMouse()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x-1, pos.y, 0);
    }

    //Insere informações novas na caixa
    public void NovasInformacoes(string titulo, string descricao, string preco)
    {
        this.titulo.GetComponent<TextMeshProUGUI>().text = titulo;
        this.descricao.GetComponent<TextMeshProUGUI>().text = descricao;
        this.preco.GetComponent<TextMeshProUGUI>().text = preco;
    }
}
