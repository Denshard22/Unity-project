using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;      // Prefab of the grenade object
    public Transform throwOrigin;         // The transform representing the position and direction from where the grenade is thrown
    public float throwForce = 10f;        // The force applied to throw the grenade

    public int maxThrows = 3;             // Maximum number of throws allowed
    private int throwsRemaining;          // Number of throws remaining

    private void Start()
    {
        throwsRemaining = maxThrows;      // Set the initial number of throws remaining
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && throwsRemaining > 0)    // Check if the E key is pressed and there are throws remaining
        {
            throwsRemaining--;    // Decrease the number of throws remaining
            ThrowGrenade();    // Throw the grenade
        }
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwOrigin.position, throwOrigin.rotation);    // Instantiate the grenade at the throw origin
        Rigidbody rb = grenade.GetComponent<Rigidbody>();    // Get the Rigidbody component of the grenade

        // Apply throwing force to the grenade
        rb.AddForce(throwOrigin.forward * throwForce, ForceMode.VelocityChange);

        // Apply random spin to the grenade for more realism
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));    // Generate a random torque vector
        rb.AddTorque(randomTorque * throwForce * 0.1f, ForceMode.VelocityChange);    // Apply torque to the grenade to make it spin
    }
}
