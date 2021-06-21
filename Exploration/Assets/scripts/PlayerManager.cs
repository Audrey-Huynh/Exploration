using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLoco playerLoco;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLoco = GetComponent<PlayerLoco>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLoco.HandleAllMovement();
    }
}


