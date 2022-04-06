using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPersonagemRefac : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody myRigidbody;
    Vector2 vetorInput;
    bool jumpInput = false;
    public float velocidade_giro = 100f;
    public float velocidade_movimento = 100f;
    public float forca_pulo = 20f;
    
    void Start()
    {
        Inicializar();
    }

    void Update()
    {
        RegistrarInputs();
        AtualizarAnimator();      

        TentarPular();
    }
    void Inicializar()
    {
        vetorInput = new Vector2();
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void RegistrarInputs()
    {
        vetorInput.x = Input.GetAxis("Horizontal");
        vetorInput.y = Input.GetAxis("Vertical");

        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

    void AtualizarAnimator()
    {
        myAnimator.SetBool("Jumping", jumpInput);
        myAnimator.SetFloat("VSpeed", vetorInput.y); 
        
    }

    void RealizarMovimento()
    {

        float rotation_final = vetorInput.x * velocidade_giro;
        Vector3 rotationVec = Vector3.up * rotation_final;
        myRigidbody.AddTorque(rotationVec, ForceMode.Force);
        

        float move_final =  vetorInput.y * velocidade_movimento;
        Vector3 moveVec = transform.forward * move_final;
        myRigidbody.AddForce(moveVec, ForceMode.Force);
    }

    void FixedUpdate() 
    {
        RealizarMovimento();
    }

    void TentarPular()
    {
        if(jumpInput)
        {
            Vector3 puloVec = Vector3.up * forca_pulo; 
            myRigidbody.AddForce(puloVec, ForceMode.Impulse);
        }
    }
}
