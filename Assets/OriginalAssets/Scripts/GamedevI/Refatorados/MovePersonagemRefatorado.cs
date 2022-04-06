using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePersonagemRefatorado : MonoBehaviour
{
    RegistroInputs controleInputs;
    ControleRigidbody controleRb;
    ControleEstados controleEstados;

    public float velocidadeMovimento;
    public float forcaPulo;

    void Awake()
    {
        controleInputs = new RegistroInputs();
        controleRb = new ControleRigidbody(GetComponent<Rigidbody>(),
                                           GetComponent<BoxCastManager>());
        controleEstados = new ControleEstados(controleRb);
    }

    void Update()
    {
        controleInputs.RegistrarInputs();
        controleEstados.Tick();
    }

    void FixedUpdate()
    {
        controleEstados.TentarMover(controleInputs.move, velocidadeMovimento);

        if(controleInputs.jump)
            controleEstados.TentarPular(forcaPulo);
    }
}
