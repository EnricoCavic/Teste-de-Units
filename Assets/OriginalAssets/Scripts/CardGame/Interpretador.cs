using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Local
{
    Mao, 
    Campo,
    Descarte
}

public class Interpretador : MonoBehaviour, IPointerEnterHandler , IPointerClickHandler, IPointerExitHandler
{
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
        transform.localScale = new Vector3(tamanhoAoSelecionar, tamanhoAoSelecionar, tamanhoAoSelecionar);
        transform.position += transform.up * (tamanhoAoSelecionar/2f) + (transform.right * (tamanhoAoSelecionar/2)) * offsetDoCanto * 0.7f;
        transform.SetAsLastSibling();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
        transform.position = originalPosition;
    }
}
