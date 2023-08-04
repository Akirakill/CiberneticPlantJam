using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float VelocidadCamara;
    public Transform ObjetivoCamara;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, ObjetivoCamara.position, VelocidadCamara * Time.deltaTime);
    }
}
