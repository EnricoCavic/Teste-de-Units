using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baralho
{
    private BaralhoObj obj;

    public List<Carta> cartas { get; private set; }

    public Baralho(BaralhoObj _obj)
    {
        obj = _obj;
        cartas = new List<Carta>();
        ConstruirBaralho();
    }

    private void ConstruirBaralho()
    {
        for(int i = 0; i < obj.cartas.Count; i++)
        {
            Carta c = new Carta(obj.cartas[i]);
            Debug.Log(c.nome + " adicionado ao baralho");
            cartas.Add(c);
            
        }
        
    }

    public Carta ComprarCarta()
    {
        if(cartas == null || cartas.Count < 1)
            return null;

        int r = Random.Range(0, cartas.Count - 1);
        Carta c = cartas[r];
        cartas.RemoveAt(r);
        return c;
    }

}
