using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interpretador : MonoBehaviour
{
    [SerializeField]
    CartaObj carta;

    public Text nome, efeito, ataque, vida;

    public RawImage imagem;

    // Start is called before the first frame update
    void Start()
    {
        Interpretar();
    }

    public void Interpretar()
    {
        if(carta == null)
            return;

        nome.text = carta.name;
        efeito.text = carta.efeito;
        ataque.text = carta.ataque.ToString();
        vida.text = carta.vida.ToString();
        imagem.texture = carta.imagem.texture;
    }
}
