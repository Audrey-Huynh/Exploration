using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoco : MonoBehaviour
{
    InputManager inputManager;
    AnimatorControl animatorControl;
    PlayerManager playerManager;
    
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rb;
    [Header("Falling")]
    public float airtimer;
    public float fallingspeed;
    public float leapingVelocity;
    public LayerMask groundLayer;
    public float rayCastheightoffset = 0.5f;

    [Header("Movement Flags")]
    public bool isGrounded;

    public float speed = 4;
    public float rspeed = 10;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorControl = GetComponent<AnimatorControl>();
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.vertical;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * speed;

        Vector3 movementVelocity = moveDirection;
        rb.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.vertical;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontal;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rspeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    public void HandleAllMovement()
    {
        HandleFallandLand();

        if(playerManager.isInteracting)
            return;
        HandleMovement();
        HandleRotation();
    }

    private void HandleFallandLand()
    {
        RaycastHit hit;
        Vector3 rayCastorigin = transform.position;
        rayCastorigin.y = rayCastorigin.y + rayCastheightoffset;

        if(!isGrounded)
        {
            if(!playerManager.isInteracting)
            {
                animatorControl.PlayTargetAnimation("Falling", true);
            }

            airtimer = airtimer + Time.deltaTime;
            rb.AddForce(transform.forward * leapingVelocity);
            rb.AddForce(-Vector3.up * fallingspeed * airtimer);
        }
        if (Physics.SphereCast(rayCastorigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if (!isGrounded && !playerManager.isInteracting)
            {
                animatorControl.PlayTargetAnimation("Landing", true);
            }

            airtimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
