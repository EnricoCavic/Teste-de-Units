using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interpretador : MonoBehaviour
{
    [SerializeField]
    public Carta carta;

    public Text nome, efeito, ataque, vida;

    public RawImage imagem;

    // Start is called before the first frame update
    void OnEnable()
    {
        Interpretar();
    }

    public void Interpretar()
    {
        if(carta == null)
            return;

        nome.text = carta.obj.name;
        efeito.text = carta.obj.efeito;
        ataque.text = carta.obj.ataque.ToString();
        vida.text = carta.obj.vida.ToString();
        imagem.texture = carta.obj.imagem.texture;
    }
}
