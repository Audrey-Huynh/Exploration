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
    private float moveAmount;
    public float vertical;
    public float horizontal;
    public float camerax;
    public float cameray;

    public bool jump_Input;

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
        //handle action input
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

}

