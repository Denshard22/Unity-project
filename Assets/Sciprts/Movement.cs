using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public GameObject pauseScreen;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool footStepIsPlaying = true;
    public float speed = 5f;
    public float sprintSpeed = 7f; // New variable for sprint speed
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    private bool isSprinting = false; // New variable to track sprinting state
    public float delay = 0.2f;
    float timer;
    float lastStepTime;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        // Check for sprint input
        // TODO: Implement sprint input logic
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        // Use sprint speed if sprinting, otherwise use normal speed
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        // Move the player
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
            //AkSoundEngine.PostEvent("Play_Walking", gameObject);
        }

        // Apply gravity to the player
        controller.Move(playerVelocity * Time.deltaTime);

        // Play footstep sound based on movement
        if (input.x > 0 || input.y > 0)
        {
            PlayFootstepSound(currentSpeed);
        }
        else if (input.x == 0 && input.y == 0)
        {
            //PlayFootstepSound(currentSpeed);
        }
    }

    void PlayFootstepSound(float currentSpeed)
    {
        // Play running sound if sprinting
        if (currentSpeed == sprintSpeed)
        {
            if (!footStepIsPlaying)
            {
                AkSoundEngine.PostEvent("Play_running", gameObject);
                lastStepTime = Time.time;
                footStepIsPlaying = true;
            }
            else
            {
                if (currentSpeed > 1)
                {
                    if (Time.time - lastStepTime > 1.5)
                    {
                        footStepIsPlaying = false;
                    }
                }
            }
        }

        // Play walking sound if not sprinting
        if (currentSpeed == speed)
        {
            if (!footStepIsPlaying)
            {
                AkSoundEngine.PostEvent("Play_Walking", gameObject);
                lastStepTime = Time.time;
                footStepIsPlaying = true;
            }
            else
            {
                if (currentSpeed > 1)
                {
                    if (Time.time - lastStepTime > 0.4)
                    {
                        footStepIsPlaying = false;
                    }
                }
            }
        }
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            // Perform jump action
            AkSoundEngine.PostEvent("Play_Jump", gameObject);
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void OnPause()
    {
        // Toggle game pause state and activate/deactivate pause screen
        DataStorage.instance.gameActive = !DataStorage.instance.gameActive;
        pauseScreen.SetActive(!DataStorage.instance.gameActive);

        // Play pause or resume sound based on game pause state
/*        if (!DataStorage.instance.gameActive)
        {
            AkSoundEngine.PostEvent("Play_Pause", gameObject);
        }
        else if (DataStorage.instance.gameActive)
        {
            AkSoundEngine.PostEvent("Stop_Pause", gameObject);
        }*/
    }

    void OnRun(InputValue val)
    {
        if (val.isPressed)
        {
            // Enable sprinting
            isSprinting = true;
        }
        else
        {
            // Disable sprinting
            isSprinting = false;
            //AkSoundEngine.PostEvent("Play_Walking", gameObject);
        }
        Debug.Log(val.isPressed);
    }
}
