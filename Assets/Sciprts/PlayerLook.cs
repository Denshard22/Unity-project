using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam; // Reference to the player's camera
    private float xRotation = 0f; // Current rotation around the x-axis

    public float xSensitivity = 30f; // Sensitivity of camera rotation around the x-axis
    public float ySensitivity = 30f; // Sensitivity of camera rotation around the y-axis

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x; // Get the horizontal input for camera rotation
        float mouseY = input.y; // Get the vertical input for camera rotation

        xRotation = (mouseY * Time.deltaTime) * ySensitivity; // Calculate the new xRotation based on vertical input
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Clamp the xRotation to limit the vertical camera angle

        // Rotate the camera around the x-axis using Euler angles (commented out in your code)
        // cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate the player object around the y-axis based on horizontal input
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
