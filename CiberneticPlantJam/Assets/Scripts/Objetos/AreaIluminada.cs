using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaIluminada : MonoBehaviour
{

    public bool InArea;
    public float Radius;
    public float PlayerDistance;
    public GameObject Player;

    private void Start()
    {
        InArea = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.localScale = new Vector3(Radius*2,Radius*2,Radius*2);
    }


    void Update()
    {
        PlayerDistance = Vector3.Distance(Player.transform.position, transform.position);

        if (PlayerDistance <= Radius) { InArea = true; }
        else { InArea = false; }


    }


    private void OnDrawGizmos()
    {
        if (InArea)
        {
            Gizmos.color = Color.blue.WithAlpha(.1f);
        }
        if (!InArea)
        {
            Gizmos.color = Color.red.WithAlpha(.1f);
        }
        Gizmos.DrawSphere(transform.position, Radius);

    }
}
