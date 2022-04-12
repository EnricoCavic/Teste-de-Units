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
    private List<Interpretador> interpretadores;

    private void Start() 
    {
        interpretadores = new List<Interpretador>();    
    }

    private void OnEnable() 
    {
        Participante.cartaAdicionada += AdicionarCarta;    
    }

    private void AdicionarCarta(Carta _carta)
    {
        Debug.Log("add carta");
        for(int i = 0; i < interpretadores.Count; i++)
        {
            if(interpretadores[i] == null)
            {
                Transform t = posicoesMao[i];
                // not instantiating here
                GameObject obj = Instantiate(prefabCarta, t.position, t.rotation);
                Interpretador interpr = obj.GetComponent<Interpretador>();
                interpr.carta = _carta;
                interpretadores[i] = interpr;
                return;
            }
        }
    }
    
}
