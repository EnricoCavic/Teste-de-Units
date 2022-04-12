using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participante : MonoBehaviour
{

    public static Action<Carta, Local> cartaAdicionada;
    public static Action<List<Carta>> cartaRemovida;

    [SerializeField]
    private BaralhoObj baralhoObj;
    private Baralho meuBaralho;

    // mão do jogador
    private List<Carta> mao = new List<Carta>();

    [SerializeField]
    private int tamanhaMaximoMao;

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
        if(mao.Count >= tamanhaMaximoMao)
            return;

        Carta c = meuBaralho.ComprarCarta();
        mao.Add(c);
        Debug.Log("Carta comprada: " + c.nome);
        cartaAdicionada?.Invoke(c, Local.Mao);
    }

}
