using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float VelocidadCamara;
    public Transform ObjetivoCamara;
    Player_Movement Target;
    float YPos;
    Vector3 TargPos;

    private void Awake()
    {
        Target = ObjetivoCamara.gameObject.GetComponent<Player_Movement>();
    }

    void FixedUpdate()
    {
        if (Target.Grounded) { YPos = ObjetivoCamara.position.y; }
        TargPos = new Vector3(ObjetivoCamara.position.x, YPos, ObjetivoCamara.position.z);
        transform.position = Vector3.Lerp(transform.position, TargPos, VelocidadCamara * Time.deltaTime);
    }
}
