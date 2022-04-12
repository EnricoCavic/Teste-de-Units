using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta
{
    public CartaObj obj { get; private set; }

    public string nome { get; private set; }
    public string efeito { get; private set; }

    public int ataqueOriginal { get; private set; }
    public int ataqueAtual { get; private set; }

    public int vidaOriginal { get; private set; }
    public int vidaAtual { get; private set; }

    public Carta(CartaObj _obj)
    {
        obj = _obj;
        ConstruirCarta();
    }

    private void ConstruirCarta()
    {
        nome = obj.name;
        efeito = obj.efeito;
        ataqueOriginal = obj.ataque;
        ataqueAtual = ataqueOriginal;
        vidaOriginal = obj.vida;
        vidaAtual = vidaOriginal;
    }
}
