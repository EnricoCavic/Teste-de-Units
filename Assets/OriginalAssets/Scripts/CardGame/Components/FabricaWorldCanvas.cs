using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaWorldCanvas : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabCarta;

    public List<LocalPositions> locais;
    
    private void Start() 
    {
        for(int i = 0; i < locais.Count; i++)
            locais[i].Inicializar();           
    }

    private void OnEnable() 
    {
        Participante.cartaAdicionada += AdicionarCarta; 
        Interpretador.cartaMovida += AdicionarCarta;
    }

    private void AdicionarCarta(Carta _carta, Local _localAtual)
    {
        LocalPositions localPos = EncontrarLocal(_localAtual);
        if(localPos == null)
            return;

        Interpretador _interpretador = Instantiate(prefabCarta).GetComponent<Interpretador>();
        MoverCarta(_interpretador, _carta, localPos);
        return;

    
    }

    private void AdicionarCarta(Interpretador _interpretador, Local _localAtual)
    {
        RemoverDoLocalAnterior();
        LocalPositions localPos = EncontrarLocal(_localAtual);
        if(localPos == null)
            return;

        MoverCarta(_interpretador, _interpretador.carta, localPos);        
    }


    private void MoverCarta(Interpretador _interpretador, Carta _carta, LocalPositions _local)
    {
        int i = EncontrarInterpretadorVazio(_local);
        if(i < 0)
            return;

        Transform t = _local.posicoes[i];
        _interpretador.gameObject.transform.SetParent(this.transform);;
        
        _interpretador.SetTransform(t);
        _interpretador.Interpretar(_carta);
        _interpretador.fabrica = this;
        _interpretador.localAtual = _local.localId;

        if(i == 0)
            _interpretador.offsetDoCanto = 1;
        else if(i == _local.interpretadores.Length - 1)
            _interpretador.offsetDoCanto = -1;
        else    
            _interpretador.offsetDoCanto = 0;

        _local.interpretadores[i] = _interpretador;

    }

    private LocalPositions EncontrarLocal(Local _localAEncontrar)
    {
        for(int i = 0; i < locais.Count; i++)
            if(locais[i].localId == _localAEncontrar)
                return locais[i];

        return null;
    }

    private int EncontrarInterpretadorVazio(LocalPositions _local)
    {
        for(int i = 0; i < _local.interpretadores.Length; i++)
            if(_local.interpretadores[i] == null)
                return i;    

        return -1;
    }

    private void RemoverDoLocalAnterior()
    {

    }
    
}
