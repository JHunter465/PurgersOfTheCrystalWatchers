using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCamera playerCamera;

    private float horizontalMove;
    private float verticalMove;

    private float horizontalRotation;
    private float verticalRotation;

    private float horizontalMouseRotation;
    private float verticalMouseRotation;

    private float crouch;
    private float run;

    PlayerInputActions inputAction;

    private Vector2 movementInput;
    private Vector2 lookInput;
    private Vector2 lookMouseInput;

    private bool jump;
    private bool pause;
    private bool inputFlag;

    #region Noah
    private bool paused;
    private bool secret1;
    private bool secret2;
    private bool secret3;
    private bool secret4;
    private bool secret5;
    #endregion

    [HideInInspector] public bool Interact;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerActions.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputAction.PlayerActions.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputAction.PlayerActions.LookMouse.performed += ctx => lookMouseInput = ctx.ReadValue<Vector2>();
        inputAction.PlayerActions.Run.performed += ctx => run = ctx.ReadValue<float>();
        inputAction.PlayerActions.Crouch.performed += ctx => crouch = ctx.ReadValue<float>();
        inputAction.PlayerActions.Interact.performed += ctx => Interact = inputAction.PlayerActions.Interact.triggered;
        inputAction.PlayerActions.Jump.performed += ctx => jump = inputAction.PlayerActions.Jump.triggered;
        #region Noah
        inputAction.PlayerActions.Pause.performed += ctx => pause = inputAction.PlayerActions.Pause.triggered;
        inputAction.PlayerActions.Secret1.performed += ctx => secret1 = inputAction.PlayerActions.Secret1.triggered;        
        inputAction.PlayerActions.Secret2.performed += ctx => secret2 = inputAction.PlayerActions.Secret2.triggered;        
        inputAction.PlayerActions.Secret3.performed += ctx => secret3 = inputAction.PlayerActions.Secret3.triggered;        
        inputAction.PlayerActions.Secret4.performed += ctx => secret4 = inputAction.PlayerActions.Secret4.triggered;        
        inputAction.PlayerActions.Secret5.performed += ctx => secret5 = inputAction.PlayerActions.Secret5.triggered;
        #endregion
        inputAction.PlayerActions.Run.canceled += ctx => run = ctx.ReadValue<float>();
        inputAction.PlayerActions.Crouch.canceled += ctx => crouch = ctx.ReadValue<float>();
        inputAction.PlayerActions.Move.canceled += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera = GetComponent<PlayerCamera>();
    }

    private void Update()
    {
        if (inputAction.PlayerActions.Jump.triggered) jump = true;
        else jump = false;
        if (inputAction.PlayerActions.Interact.triggered) Interact = true;
        else Interact = false;
        if (inputAction.PlayerActions.Pause.triggered) pause = true;
        else pause = false;

        horizontalMove = movementInput.x;
        verticalMove = movementInput.y;

        horizontalRotation = lookInput.x;
        verticalRotation = lookInput.y;

        if (horizontalMouseRotation == lookMouseInput.x && verticalMouseRotation == lookMouseInput.y)
        {
            inputFlag = true;
        }
        else
        {
            inputFlag = false;
        }

        horizontalMouseRotation = lookMouseInput.x;
        verticalMouseRotation = lookMouseInput.y;
    }

    private void FixedUpdate()
    {
        playerMovement.Move(horizontalMove, verticalMove, jump, crouch, run);
        playerCamera.Look(horizontalRotation, verticalRotation, horizontalMouseRotation, verticalMouseRotation, inputFlag);
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
