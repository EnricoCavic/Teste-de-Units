using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ControleRigidbody
{
    Rigidbody rb;
    BoxCastManager boxCast;

    public ControleRigidbody(Rigidbody _rb, BoxCastManager _boxCast)
    {
        rb = _rb;
        boxCast = _boxCast;
    }

    // retorno de informações
    public bool EstaNoChao() => boxCast.CheckCast("GroundCheck");

    public bool EstaMovendo() => Mathf.Abs(rb.velocity.x) > 0.02f ||
                          Mathf.Abs(rb.velocity.z) > 0.02f;

    public bool EstaCaindo() => rb.velocity.y < 0f;

    public bool MovendoVertical() => Math.Abs(rb.velocity.y) > float.Epsilon;

    // ações do rigigbody
    public void Mover(Vector3 _moveInput, float _velocidadeMovimento)
    {
        rb.AddForce(_moveInput * _velocidadeMovimento, ForceMode.Force);
    }

    public void Pular(float _forcaPulo)
    {
        rb.AddForce(Vector3.up * _forcaPulo, ForceMode.Impulse);
    }


}
