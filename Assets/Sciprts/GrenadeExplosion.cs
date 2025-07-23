using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public float explosionRadius = 5f;                   // Radius of the explosion
    public LayerMask explosionLayers;                    // Layers affected by the explosion
    public float destroyDelay = 1.5f;                    // Delay before destroying the grenade
    public ParticleSystem explosionParticles;            // Particle system for explosion visual effects

    private bool exploded = false;                       // Flag to track if the grenade has exploded

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))    // Check if the grenade collides with an object tagged as "Floor"
        {
            // Perform the explosion when the grenade hits the floor
            Explode();
            exploded = true;

            // Destroy the grenade after a delay
            Invoke("DestroyGrenade", destroyDelay);
        }
    }

    private void Explode()
    {
        // Instantiate the explosion particle system at the grenade's position
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        // Get all colliders within the explosion radius and on the specified layers
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayers);

        // Loop through all colliders and apply damage to enemies
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Zombie"))            // Check if the collider belongs to an object tagged as "Zombie"
            {
                // Get the EnemyStats component from the enemy object
                var enemyStats = collider.gameObject.GetComponent<EnemyStats>();

                // Reduce the health of the enemy by 20 using the ReduceHealth method
                enemyStats.ReduceHealth(20);
            }
        }
    }

    private void DestroyGrenade()
    {
        // Destroy the grenade game object
        Destroy(gameObject);
    }
}
