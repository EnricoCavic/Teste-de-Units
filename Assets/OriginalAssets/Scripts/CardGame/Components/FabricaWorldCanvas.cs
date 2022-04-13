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
        Participante.cartaAdicionada += AdicionarCartaAoLocal; 
        Interpretador.cartaMovida += AdicionarInterpretadorAoLocal;
    }

    private void AdicionarCartaAoLocal(Carta _carta, Local _novoLocal)
    {
        LocalPositions novoLocalPos = EncontrarLocal(_novoLocal);
        if(novoLocalPos == null)
            return;

        Interpretador _interpretador = Instantiate(prefabCarta).GetComponent<Interpretador>();
        _interpretador.carta = _carta;
        MoverCarta(_interpretador, novoLocalPos);   
    }

    private void AdicionarInterpretadorAoLocal(Interpretador _interpretador, Local _novoLocal)
    {
        LocalPositions novoLocalPos = EncontrarLocal(_novoLocal);
        EncontrarLocal(_interpretador.localAtual).RemoverInterpretador(_interpretador);
        if(novoLocalPos == null)
            return;

        MoverCarta(_interpretador, novoLocalPos);        
    }


    private void MoverCarta(Interpretador _interpretador, LocalPositions _localAlvo)
    {
        int i = _localAlvo.EncontrarInterpretadorVazio();
        if(i < 0)
            return;

        Transform t = _localAlvo.posicoes[i];
        _interpretador.gameObject.transform.SetParent(this.transform);;
        
        _interpretador.SetTransform(t);
        _interpretador.Interpretar();
        _interpretador.localAtual = _localAlvo.localId;

        if(i == 0)
            _interpretador.offsetDoCanto = 1;
        else if(i == _localAlvo.interpretadores.Length - 1)
            _interpretador.offsetDoCanto = -1;
        else    
            _interpretador.offsetDoCanto = 0;

        _localAlvo.interpretadores[i] = _interpretador;

    }

    private LocalPositions EncontrarLocal(Local _localAEncontrar)
    {
        for(int i = 0; i < locais.Count; i++)
            if(locais[i].localId == _localAEncontrar)
                return locais[i];

        return null;
    }
    
}
