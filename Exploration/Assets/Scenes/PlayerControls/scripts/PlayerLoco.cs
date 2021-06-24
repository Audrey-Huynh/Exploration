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
    public static int iron = 0;

    [Header("Movement Flags")]
    public bool isGrounded;
    public bool isJumping;
    public float speed = 7;
    public float rspeed = 10;

    [Header("Jump Speeds")]
    public float gravityIntensity = -30;
    public float jumpHeight = 4f;

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
        if (isJumping)
            return;
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
        if (isJumping)
            return;
        
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

    public void HandleJumping()
    {
        if(isGrounded)
        {
            animatorControl.animator.SetBool("isJumping", true);
            animatorControl.PlayTargetAnimation("Jump", false);

            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = moveDirection;
            playerVelocity.y = jumpingVelocity;
            rb.velocity = playerVelocity;
        }
    }

    private void HandleFallandLand()
    {
        RaycastHit hit;
        Vector3 rayCastorigin = transform.position;
        Vector3 targetPosition;
        rayCastorigin.y = rayCastorigin.y + rayCastheightoffset;
        targetPosition = transform.position;

        if(!isGrounded && !isJumping)
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

            Vector3 rayCastHitpoint = hit.point;
            targetPosition.y = rayCastHitpoint.y;
            airtimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && !isJumping)
        {
            if(playerManager.isInteracting || inputManager.moveAmount > 0)
            {
                transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
            }
            else
            {
                transform.position = targetPosition;
            }
        }
    }

    public void Craft()
    {
        if (isGrounded && iron >= 3)
        {
            animatorControl.animator.SetBool("isCrafting", true);
            animatorControl.PlayTargetAnimation("Craft", false);
            ++PlayerHealth.playerHealth;
            Debug.Log("Iron: " + (iron -=3));
        }
    }
    
    public void Attack()
    {
        if(isGrounded)
        {
            animatorControl.animator.SetBool("isAttacking", true);
            animatorControl.PlayTargetAnimation("Attack", false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("iron"))
        {
            Destroy(other.gameObject);
            Debug.Log("Iron: " + (++iron));
        }
    }

}
