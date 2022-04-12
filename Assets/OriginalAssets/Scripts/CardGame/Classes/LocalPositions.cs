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

    [NonSerialized]
    public Interpretador[] interpretadores;

    public void Inicializar()
    {
        interpretadores = new Interpretador[posicoes.Count];
    }

}
