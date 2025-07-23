using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //   public int bulletLife = 5; // Time in seconds before the bullet is destroyed
    public int damage;

    private void Awake()
    {
        // Destroy the bullet game object after the specified bulletLife time
   //     Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Zombie"
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Get the EnemyStats component from the collided object
            var enemyStats = collision.gameObject.GetComponent<EnemyStats>();

            // Reduce the health of the enemy by 1 using the ReduceHealth method
            enemyStats.ReduceHealth(damage);
        }
    }
}
