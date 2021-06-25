using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorControl animatorControl;
    PlayerLoco playerLoco;

    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float moveAmount;
    public float vertical;
    public float horizontal;
    public float camerax;
    public float cameray;

    public bool jump_Input;
    public bool attack_Input;
    public bool craft_Input;
    public bool pause_Input;

    private void Awake()
    {
        animatorControl = GetComponent<AnimatorControl>();
        playerLoco = GetComponent<PlayerLoco>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
            playerControls.PlayerActions.Attack.performed += i => attack_Input = true;
            playerControls.PlayerActions.Craft.performed += i => craft_Input = true;
            playerControls.PlayerActions.Pause.performed += i => pause_Input = true;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleAttackInput();
        HandleCraftInput();
        HandlePauseInput();
    }

    private void HandleMovementInput()
    {
        vertical = movementInput.y;
        horizontal = movementInput.x;

        camerax = cameraInput.x;
        cameray = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        animatorControl.UpdateAnimatorValue(0, moveAmount);
    }

    private void HandleJumpInput()
    {
        if(jump_Input == true)
        {
            jump_Input = false;
            playerLoco.HandleJumping();
        }
    }

    private void HandleAttackInput()
    {
        if(attack_Input == true)
        {
            attack_Input = false;
            playerLoco.Attack();
        }
    }

    private void HandleCraftInput()
    {
        if(craft_Input == true)
        {
            craft_Input = false;
            playerLoco.Craft();
        }
    }

    private void HandlePauseInput()
    {
        if(pause_Input == true)
        {
            pause_Input = false;
            
        }
    }

}

