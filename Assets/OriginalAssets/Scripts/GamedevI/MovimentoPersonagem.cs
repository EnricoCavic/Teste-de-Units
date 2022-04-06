// bibliotecas/libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// classe principal
public class MovimentoPersonagem : MonoBehaviour
{
    string nome = "Enrico Lima";
    int idade = 25;
    float altura = 1.84f;
    bool gosta_de_programar = true;

    // variável do tipo de um componente 
    Rigidbody myRigidbody;

    // variável que registra os inputs do jogador
    public Vector3 inputAxis;
    public bool jumpInput = false;

    // registro de colisão direcional
    BoxCastManager boxCast;

    public float velocidade = 20f;
    public float forca_pulo = 5f;

    // definição dos estados
    const string PARADO = "parado";
    const string CORRENDO = "correndo";
    const string PULANDO = "pulando";
    const string CAINDO = "caindo";

    string estadoAtual = PARADO;

    // função que ocorre uma vez ao iniciar o jogo
    void Start()
    {
        transform.name = nome;
        Debug.Log("Idade é " + idade);
        Debug.Log("Minha altura é " + altura + " metros");

        // guardando o componente na variável
        myRigidbody = GetComponent<Rigidbody>();
        boxCast = GetComponent<BoxCastManager>();

        inputAxis = new Vector3();

    }

    // função que ocorre uma vez por frame
    void Update()
    {
        // registrar inputs no update
        RegistrarInputs();

        switch (estadoAtual)
        {
            case PARADO:
                if(EstaMovendo())
                    estadoAtual = CORRENDO;

                break;

            case CORRENDO:
                if(EstaCaindo() && !EstaNoChao())
                    estadoAtual = CAINDO;

                if(!EstaMovendo())
                    estadoAtual = PARADO;

                break;

            case PULANDO:
                if(EstaCaindo())
                    estadoAtual = CAINDO;

                break;

            case CAINDO:
                if(EstaNoChao())
                    estadoAtual = PARADO;

                break;
            default:
                break;
        }

        Debug.Log(estadoAtual);

    }

    void FixedUpdate()
    {
        Mover();
        TentarPular();
    }

    void RegistrarInputs()
    {
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.z = Input.GetAxis("Vertical");
        jumpInput = Input.GetKey(KeyCode.Space);
    }

    void Mover()
    {
        // aplicar forças e movimentação no fixed update
        myRigidbody.AddForce(inputAxis * velocidade, ForceMode.Force);
    }

    void TentarPular()
    {
        if(jumpInput && EstaNoChao())
        {
            myRigidbody.AddForce(Vector3.up * forca_pulo, ForceMode.Impulse);
            estadoAtual = PULANDO;
        }
    }

    bool EstaNoChao() => boxCast.CheckCast("GroundCheck");
    bool EstaMovendo() => Mathf.Abs(myRigidbody.velocity.x) > 0.02f ||
                          Mathf.Abs(myRigidbody.velocity.z) > 0.02f;

    bool EstaCaindo() => myRigidbody.velocity.y < 0f;
    
}
