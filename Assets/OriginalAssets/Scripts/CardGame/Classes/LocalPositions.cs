using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LocalPositions
{

    public Local localId;

    // transform de onde as cartas devem ficar
    public List<Transform> posicoes;

    // interpretadores(cartas) registradas neste local
    // posição dele na array é o mesmo do transform que ele se encontra
    [NonSerialized]
    public Interpretador[] interpretadores;

    public void Inicializar()
    {
        interpretadores = new Interpretador[posicoes.Count];
    }

    public int EncontrarInterpretadorVazio()
    {
        for(int i = 0; i < interpretadores.Length; i++)
            if(interpretadores[i] == null)
                return i;    

        return -1;
    }

    public void RemoverInterpretador(Interpretador _interpretador)
    {
        for(int i = 0; i < interpretadores.Length; i++)
            if(interpretadores[i] == _interpretador)
                interpretadores[i] = null;
    }

}
