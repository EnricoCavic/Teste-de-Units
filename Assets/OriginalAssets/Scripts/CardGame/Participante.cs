using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participante : MonoBehaviour
{
    public BaralhoObj baralhoObj;
    private Baralho meuBaralho;

    private void Awake()
    {
        meuBaralho = new Baralho(baralhoObj);  
    }
}
