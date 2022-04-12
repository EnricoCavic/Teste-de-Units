using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaWorldCanvas : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabCarta;

    // transform de onde as cartas devem ficar na mão
    [SerializeField]
    private List<Transform> posicoesMao;
    private Interpretador[] interpretadores;

    private void Start() 
    {
        interpretadores = new Interpretador[posicoesMao.Count];
    }

    private void OnEnable() 
    {
        Participante.cartaAdicionada += AdicionarCarta;    
    }

    private void AdicionarCarta(Carta _carta)
    {
        for(int i = 0; i < interpretadores.Length; i++)
        {
            if(interpretadores[i] == null)
            {
                Transform t = posicoesMao[i];
                GameObject obj = Instantiate(prefabCarta, t.position, t.rotation, transform);
                Interpretador interpr = obj.GetComponent<Interpretador>();

                obj.transform.localScale = t.localScale;
                interpr.Interpretar(_carta);
                interpr.fabrica = this;
                if(i == 0)
                    interpr.offsetDoCanto = 1;
                else if(i == interpretadores.Length - 1)
                    interpr.offsetDoCanto = -1;
                else    
                    interpr.offsetDoCanto = 0;

                interpretadores[i] = interpr;
                return;
            }
        }
    }
    
}
