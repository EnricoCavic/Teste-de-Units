using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova carta", menuName = "Carta")]
public class CartaObj : ScriptableObject 
{
    public string efeito;
    public int ataque, vida;    
    public Sprite imagem;
}
