using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator AnimCtrl;
    bool Set1;
    [SerializeField]Player_Movement PM;

    public GameObject Arms, Legs;
    void Start()
    {
        Set1 = false;
        AnimCtrl = GetComponent<Animator>();
        PM = GetComponentInParent<Player_Movement>();
    }
    void Update()
    {
        if (PM.Completo) { Arms.SetActive(true); Legs.SetActive(true); }else { Arms.SetActive(false); Legs.SetActive(false); }
        UpdateAnimations();
    }

    void UpdateAnimations() 
    {
        Set1 = PM.Completo;

        if (Set1) { AnimCtrl.SetBool("Completo", true); }
        else { AnimCtrl.SetBool("Completo", false); }

        AnimCtrl.SetBool("Moving", PM.Moving);
    }
}
