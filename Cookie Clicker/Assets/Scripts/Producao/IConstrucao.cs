using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConstrucao
{
    void CompraConstrucao();

    void AumentaPreço();

    void AumentaQtd();

    void ChecaSePodeComprar();

    void IncrementaCps(int value);

    void AtualizaUI();
}
