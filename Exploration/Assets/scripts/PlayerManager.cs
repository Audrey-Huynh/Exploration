using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    PlayerLoco playerLoco;
    CameraManager cameraManager;

    public bool isInteracting;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        playerLoco = GetComponent<PlayerLoco>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLoco.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCamera();

        isInteracting = animator.GetBool("isInteracting");
    }
}


