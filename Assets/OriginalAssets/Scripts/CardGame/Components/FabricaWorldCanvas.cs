using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaWorldCanvas : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabCarta;


    public List<LocalPositions> locais;
    
    // [SerializeField]
    // private List<Transform> posicoesMao;
    // private Interpretador[] interpretadores;

    private void Start() 
    {
        for(int i = 0; i < locais.Count; i++)
            locais[i].Inicializar();           
    }

    private void OnEnable() 
    {
        Participante.cartaAdicionada += AdicionarCarta;    
    }

    private void AdicionarCarta(Carta _carta, Local _localAtual)
    {
        for(int i = 0; i < locais.Count; i++)
        {
            if(locais[i].localId == _localAtual)
            {
                InstanciarCarta(_carta,locais[i]);
                return;
            }
        }
    }

    private void InstanciarCarta(Carta _carta, LocalPositions _local)
    {
        for(int i = 0; i < _local.interpretadores.Length; i++)
        {
            if(_local.interpretadores[i] == null)
            {
                Transform t = _local.posicoes[i];
                GameObject obj = Instantiate(prefabCarta, t.position, t.rotation, transform);
                Interpretador interpretador = obj.GetComponent<Interpretador>();

                obj.transform.localScale = t.localScale;
                interpretador.Interpretar(_carta);
                interpretador.fabrica = this;

                if(i == 0)
                    interpretador.offsetDoCanto = 1;
                else if(i == _local.interpretadores.Length - 1)
                    interpretador.offsetDoCanto = -1;
                else    
                    interpretador.offsetDoCanto = 0;

                _local.interpretadores[i] = interpretador;
                return;
            }
        }
    }
    
}
