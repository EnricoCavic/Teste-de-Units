using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participante : MonoBehaviour
{

    public static Action<Carta, Local> cartaAdicionada;

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

    private void OnEnable() 
    {
        Interpretador.cartaMovida += RemoverCarta;
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
        cartaAdicionada?.Invoke(c, Local.Mao);
    }

    private void RemoverCarta(Interpretador _interpretador, Local _localAtual)
    {
        if(mao.Count >= tamanhaMaximoMao)
            return;

        Carta c = EncontrarCartaNaMao(_interpretador.carta);
        if(c != null)
        {
            mao.Remove(c);
        }
    }

    private Carta EncontrarCartaNaMao(Carta _carta)
    {
        for(int i = 0; i < mao.Count; i++)
            if(mao[i] == _carta)
                return mao[i];

        return null;        
    }

}
