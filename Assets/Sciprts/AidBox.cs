using UnityEngine;

public class AidBox : MonoBehaviour
{
    private float rotationSpeed = 20f; // Adjust this value to control the rotation speed

    private void Update()
    {
        // Rotate the object around the Y-axis gradually
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataStorage.instance.RestoreHealth(); // Decrease the player's health using the DataStorage class
            Destroy(gameObject);
        }
    }
}
