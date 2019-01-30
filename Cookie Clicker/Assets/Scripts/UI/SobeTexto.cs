using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SobeTexto : MonoBehaviour
{
    public void Inicializa()
    {
        this.GetComponent<TextMeshProUGUI>().text = "+ " +Cookie.cookiesPerClick.ToString();
        Invoke("Desativa", 1.5f);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0.04f, 0);
    }

    private void Desativa()
    {
        this.gameObject.SetActive(false);
    }
}
