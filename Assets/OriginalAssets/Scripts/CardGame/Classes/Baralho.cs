using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baralho
{
    private BaralhoObj obj;

    private List<Carta> cartas;

    public Baralho(BaralhoObj _obj)
    {
        obj = _obj;
        ConstruirBaralho();
    }

    private void ConstruirBaralho()
    {
        for(int i = 0; i < obj.cartas.Count; i++)
            cartas.Add(new Carta(obj.cartas[i]));
        
    }

    public Carta ComprarCarta()
    {
        int r = Random.Range(0, cartas.Count - 1);
        Carta c = cartas[r];
        cartas.RemoveAt(r);
        return c;
    }

}
