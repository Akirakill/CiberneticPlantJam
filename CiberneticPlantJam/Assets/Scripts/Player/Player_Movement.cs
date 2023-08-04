using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Velocidad;
    float MinVel;
    Player_Inputs In_;
    Vector2 Direction;
    Rigidbody Rbody;
    void Start()
    {
        In_ = gameObject.GetComponent<Player_Inputs>();   
        Rbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CharMovement();
    }

    private void CharMovement()
    {
        Direction = In_.DirInput; 
        Direction = Direction.normalized;
        Rbody.velocity = ( new Vector3 (Direction.x * ((Velocidad *100f) * Time.deltaTime),0f,Direction.y * ((Velocidad * 100f) * Time.deltaTime)));
    }
}
