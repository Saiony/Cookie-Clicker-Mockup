using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogaCookie : MonoBehaviour
{
    public void Inicializa()
    {
        JogaDirecaoAleatoria();
        Invoke("Desativa", 0.5f);
    }

    private void JogaDirecaoAleatoria()
    {
        float direcaoX = Random.Range(-50, 50);
        float direcaoY = Random.Range(0, 90);
        float forca = Random.Range(1, 3);

        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(direcaoX, 90) * forca);
    }

    private void Desativa()
    {
        this.gameObject.SetActive(false);
    }
}
