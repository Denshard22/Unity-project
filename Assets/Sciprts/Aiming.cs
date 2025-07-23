using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public Camera camera; // Reference to the Camera component

    // Coroutine zoomCoroutine; (Commented out, not being used)

    void Update()
    {
        // Update method is empty, no code inside
    }

    // Input event handler for aiming
    void OnAim(InputValue val)
    {
        // Check if the input value is pressed
        if (val.isPressed)
        {
            // Play a sound event using AkSoundEngine (assumed external audio middleware)
            AkSoundEngine.PostEvent("Play_Aim", gameObject);

            // Set the "aim" parameter in the Animator to true
            animator.SetBool("aim", true);
        }
        else
        {
            // Set the "aim" parameter in the Animator to false
            animator.SetBool("aim", false);
        }
    }
}
