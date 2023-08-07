using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Inputs : MonoBehaviour
{
    public bool Up_, Down_, Left_, Right_, Jump_, Action_, Pause_;
    Player_Input_Actions _Inp;
    InputAction MoveAction;
    InputAction JumpAction;
    InputAction CharacterAction;
    InputAction PauseAction;
    [HideInInspector]public Vector2 DirInput = Vector2.zero;

    private void Awake()
    {
        _Inp = new Player_Input_Actions();
    }
    private void OnEnable()
    {
        MoveAction = _Inp.GameplayMAP.MoveAction;
        JumpAction = _Inp.GameplayMAP.JumpAction;
        CharacterAction = _Inp.GameplayMAP.CharacterAction;
        PauseAction = _Inp.GameplayMAP.PauseAction;


        JumpAction.Enable();
        CharacterAction.Enable();
        PauseAction.Enable();
        MoveAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
        JumpAction.Disable();
        CharacterAction.Disable();
        PauseAction.Disable();
    }

    void Update()
    {
        DirInput = MoveAction.ReadValue<Vector2>();
        Up_ = DirInput.y > 0;
        Down_ = DirInput.y < 0;
        Left_ = DirInput.x < 0;
        Right_ = DirInput.x > 0;

        Jump_ = JumpAction.ReadValue<float>() >= 1;
        Action_ = CharacterAction.ReadValue<float>() >= 1;
        Pause_= PauseAction.ReadValue<float>() >= 1;
    }
}
