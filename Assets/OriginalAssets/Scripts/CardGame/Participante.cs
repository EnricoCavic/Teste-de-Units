using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participante : MonoBehaviour
{

    public static Action<Carta> cartaAdicionada;
    public static Action<List<Carta>> cartaRemovida;

    [SerializeField]
    private BaralhoObj baralhoObj;
    private Baralho meuBaralho;

    // mão do jogador
    private List<Carta> mao = new List<Carta>();

    private void Awake() 
    {
        meuBaralho = new Baralho(baralhoObj);    
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ComprarCarta();
        }
    }

    private void ComprarCarta()
    {
        Carta c = meuBaralho.ComprarCarta();
        Debug.Log(c.nome);
        mao.Add(c);
        cartaAdicionada?.Invoke(c);
    }

}
