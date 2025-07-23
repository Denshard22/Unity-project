using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; // Reference to the PlayerInput component
    private PlayerInput.PlayerActions player; // Reference to the PlayerActions from PlayerInput

    private Movement movement; // Reference to the Movement script
    private PlayerLook look; // Reference to the PlayerLook script

    void Awake()
    {
        playerInput = new PlayerInput(); // Create a new instance of PlayerInput
        player = playerInput.Player; // Get the PlayerActions from PlayerInput
        movement = GetComponent<Movement>(); // Get the Movement script component
        look = GetComponent<PlayerLook>(); // Get the PlayerLook script component
    }

    void FixedUpdate()
    {
        movement.ProcessMove(player.Movement.ReadValue<Vector2>()); // Pass the movement input values to the Movement script
    }

    private void LateUpdate()
    {
        look.ProcessLook(player.Look.ReadValue<Vector2>()); // Pass the look input values to the PlayerLook script
    }

    private void OnEnable()
    {
        player.Enable(); // Enable the PlayerActions
    }

    private void OnDisable()
    {
        player.Disable(); // Disable the PlayerActions
    }
}
