using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Velocidad;
    float VelMin;
    float VelActual;
    public bool Completo;
    Player_Inputs In_;
    Vector2 Direction;
    Rigidbody Rbody;
    public GameObject Model;
    public float VelRotacion;
    void Start()
    {
        In_ = gameObject.GetComponent<Player_Inputs>();   
        Rbody = gameObject.GetComponent<Rigidbody>();
        VelMin = Velocidad / 2.5f;
    }
    private void Update()
    {
        RotarModelo();
    }
    void FixedUpdate()
    {
        CharMovement();
    }

    private void CharMovement()
    {
        if (Completo) { VelActual = Velocidad; }else if (!Completo) { VelActual = VelMin; }

        Direction = In_.DirInput; 
        Direction = Direction.normalized;
        Rbody.velocity = ( new Vector3 (Direction.x * ((VelActual * 100f) * Time.deltaTime),0f,Direction.y * ((VelActual * 100f) * Time.deltaTime)));
    }

    void RotarModelo() 
    {
        Vector3 LookDir = new Vector3(Direction.x,0,Direction.y);
        if (LookDir != Vector3.zero) 
        {
            Quaternion ToRot = Quaternion.LookRotation(LookDir,Vector3.up);
            Model.transform.rotation = Quaternion.Lerp(Model.transform.rotation, ToRot, VelRotacion * Time.deltaTime);
        }
    }
}
