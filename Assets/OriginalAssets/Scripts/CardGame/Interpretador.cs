using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public enum Local
{
    Mao, 
    Campo,
    Descarte
}

public class Interpretador : MonoBehaviour, IPointerEnterHandler , IPointerClickHandler, IPointerExitHandler
{

    public static Action<Interpretador, Local> cartaMovida;


    [SerializeField]
    public Carta carta;

    [SerializeField]
    private float tamanhoAoSelecionar;

    public Text nome, efeito, ataque, vida;

    public RawImage imagem;

    private Vector3 originalPosition;
    private Vector3 originalScale;

    public float offsetDoCanto;

    public FabricaWorldCanvas fabrica;

    public Local localAtual;

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

    public void Interpretar(Carta _carta)
    {
        carta = _carta;
        Interpretar();
    }

    public void SetTransform(Transform _t)
    {
        transform.position = _t.position;
        transform.rotation = _t.rotation;
        transform.localScale = _t.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(localAtual == Local.Mao)
            HighlightMao();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(localAtual == Local.Mao)
        {
            cartaMovida?.Invoke(this, Local.Campo);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(localAtual == Local.Mao)
            RetornarAoTransformOriginal();
    }

    private void HighlightMao()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
        transform.localScale = new Vector3(tamanhoAoSelecionar, tamanhoAoSelecionar, tamanhoAoSelecionar);
        transform.position += transform.up * (tamanhoAoSelecionar/2f) + (transform.right * (tamanhoAoSelecionar/2)) * offsetDoCanto * 0.7f;
        transform.SetAsLastSibling();
    }

    private void RetornarAoTransformOriginal()
    {
        transform.localScale = originalScale;
        transform.position = originalPosition;
    }
}
