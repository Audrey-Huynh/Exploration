using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoco : MonoBehaviour
{
    InputManager inputManager;
    
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rb;

    public float speed = 4;
    public float rspeed = 10;

    private void Awake()
    {
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
        HandleMovement();
        HandleRotation();
    }
}
