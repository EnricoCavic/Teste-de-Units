using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Baralho", menuName = "Baralho")]
public class BaralhoObj : ScriptableObject 
{
    public List<CartaObj> cartas;
}