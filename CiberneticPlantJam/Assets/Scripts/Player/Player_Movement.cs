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
   [HideInInspector]public bool Grounded;
    public AnimationCurve CurvaSalto;
    public AnimationCurve CurvaCaida;
    bool Jumped;
    float YVal;
    public float AlturaSalto;
    float AltSaltoReal;
    bool CanJump;
    float tiempo;
    public float ValCurva;
    [HideInInspector] public bool Moving;
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
        CharJump();  
        

    }

    private void CharMovement()
    {
        if (Completo) { VelActual = Velocidad; CanJump = true; }else if (!Completo) { VelActual = VelMin; CanJump = false; }

        Direction = In_.DirInput; 
        Direction = Direction.normalized;
        Rbody.velocity = ( new Vector3 (Direction.x * ((VelActual * 100f) * Time.deltaTime),0f,Direction.y * ((VelActual * 100f) * Time.deltaTime)));

        if (Direction != Vector2.zero) { Moving = true; } else { Moving = false; }
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

    void CharJump()
    {
        RaycastHit hit;
        Vector3 RayStartPos = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);

        if (Physics.Raycast(RayStartPos, -transform.up, out hit, .5f) && hit.transform.tag != ("NoCollision")) 
        {
            Grounded = true;
        }
        else { Grounded = false; }

        Debug.DrawRay(transform.position, -transform.up, Color.red);




        if (In_.Jump_ && Grounded && CanJump) 
        {
            Jumped = true;
            In_.Jump_ = false;
        }

        if (Jumped) 
        {

            tiempo += Time.deltaTime;
            ValCurva = CurvaSalto.Evaluate(tiempo);
            YVal = Mathf.MoveTowards(transform.position.y, AltSaltoReal,  ValCurva/AlturaSalto);
            transform.position = new Vector3(transform.position.x, YVal, transform.position.z);
        }

        if (Jumped && YVal >= AltSaltoReal-.25f) 
        {
            tiempo = 0;
            Jumped = false;

        }

        if (!Grounded && !Jumped) 
        {
            tiempo += Time.deltaTime;
            ValCurva = CurvaCaida.Evaluate(tiempo);
            YVal = Mathf.MoveTowards(YVal, -2.5f, ValCurva);
            transform.position = new Vector3(transform.position.x, YVal, transform.position.z);
        }

        if (Grounded) 
        {
            tiempo = 0;
            YVal = transform.position.y;
            AltSaltoReal = transform.position.y + AlturaSalto;
        }
    }
}
