using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorControl animatorControl;

    public Vector2 movementInput;
    public Vector2 cameraInput;
    private float moveAmount;
    public float vertical;
    public float horizontal;
    public float camerax;
    public float cameray;

    private void Awake()
    {
        animatorControl = GetComponent<AnimatorControl>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
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
        //handle jump input
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

}

