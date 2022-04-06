using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPersonagem : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody myRigidbody;
    Vector2 vetorInput;
    public float velocidade_giro = 100f;
    public float velocidade_movimento = 100f;
    
    void Start()
    {
        vetorInput = new Vector2();
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vetorInput.x = Input.GetAxis("Horizontal");
        vetorInput.y = Input.GetAxis("Vertical");

        myAnimator.SetFloat("Vertical", vetorInput.y); 

        float rotation_final = vetorInput.x * velocidade_giro;
        Vector3 rotationVec = Vector3.up * rotation_final;
        transform.Rotate(rotationVec);

        float move_final =  vetorInput.y * velocidade_movimento;
        Vector3 moveVec = transform.forward * move_final;
        myRigidbody.AddForce(moveVec, ForceMode.Acceleration);
    }

}
