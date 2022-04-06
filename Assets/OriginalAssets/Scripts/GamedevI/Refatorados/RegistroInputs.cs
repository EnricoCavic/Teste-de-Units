using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistroInputs
{
    public bool jump;
    public Vector3 move;
    public RegistroInputs()
    {
        move = new Vector3();
        jump = false;
    }

    public void RegistrarInputs()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        jump = Input.GetKey(KeyCode.Space);
    }
}
