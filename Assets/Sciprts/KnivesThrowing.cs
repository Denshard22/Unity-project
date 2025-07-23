using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnivesThrowing : MonoBehaviour
{
    [Header("References")]
    public Transform cam;                // Reference to the player's camera
    public Transform attackPoint;        // Point from where the knife is thrown
    public GameObject objectToThrow;     // Prefab of the object to throw
    public GameObject knife;             // Knife object in the player's hand

    [Header("Settings")]
    public int totalThrows;              // Total number of throws allowed
    public float throwCooldown;          // Cooldown between throws

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;    // Key to initiate the throw
    public float throwForce;                       // Force applied to the thrown object
    public float throwUpwardForce;                  // Upward force applied to the thrown object

    bool readyToThrow;                  // Flag to track if the player is ready to throw

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();    // Throw the knife
        }
        if (totalThrows <= 0)
        {
            knife.SetActive(false);    // Hide the knife when there are no more throws
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // Instantiate the object to throw at the attack point position and with the camera rotation
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // Get the Rigidbody component of the projectile
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Calculate the throw direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;    // Adjust the throw direction towards the hit point
        }

        // Calculate the force to apply to the projectile
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        // Add the force to the projectile
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        // Rotate the projectile while it is flying
        projectileRb.angularVelocity = new Vector3(0f, 10f, 0f);    // Adjust the rotation speed as desired

        totalThrows--;
        Invoke(nameof(ResetThrow), throwCooldown);    // Reset the throw after the specified cooldown
    }

    private void ResetThrow()
    {
        readyToThrow = true;    // Set the player ready to throw again
    }
}
