using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleEstados
{
    ControleRigidbody controleRb;

    // definição dos estados
    public const string PARADO = "parado";
    public const string CORRENDO = "correndo";
    public const string PULANDO = "pulando";
    public const string CAINDO = "caindo";
    public const string MORTO = "morto";

    string estadoAtual = PARADO;
    public ControleEstados(ControleRigidbody _controleRb)
    {
        controleRb = _controleRb;
    }

    public void Tick()
    {
        string proximoEstado = ProcessarEstado();
        if(proximoEstado != estadoAtual)
            estadoAtual = proximoEstado;
    }

    string ProcessarEstado()
    {
        switch (estadoAtual)
        {
            case MORTO:
                return MORTO;

            case PARADO:
                if(controleRb.EstaMovendo())
                    return CORRENDO;
            break;

            case CORRENDO:
                if(controleRb.EstaCaindo() && !controleRb.EstaNoChao())
                    return CAINDO;


                if(!controleRb.EstaMovendo())
                    return PARADO; 

                break;

            case PULANDO:
                if(controleRb.EstaCaindo() && !controleRb.EstaNoChao())
                    return CAINDO;
                  
                if(controleRb.EstaNoChao() && !controleRb.MovendoVertical())
                    return PARADO;

                break;

            case CAINDO:
                if(controleRb.EstaNoChao())
                    return PARADO;

                break;

            default:
                break;
        }

        Debug.Log(estadoAtual);
        return estadoAtual;
    }

    public void TentarPular(float _forcaPulo)
    {
        if(estadoAtual == PARADO || estadoAtual == CORRENDO)
        {
            controleRb.Pular(_forcaPulo);
            estadoAtual = PULANDO;
        }
    }

    public void TentarMover(Vector3 _moveInput, float _velocidadeMovimento)
    {
        if(estadoAtual != MORTO)
        {
            controleRb.Mover(_moveInput, _velocidadeMovimento);
        }
    }

}
