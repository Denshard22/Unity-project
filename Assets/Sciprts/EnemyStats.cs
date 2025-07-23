using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent; // Reference to the NavMeshAgent component

    public Animator animator; // Reference to the Animator component

    private ZombieCollision collision; // Reference to the ZombieCollision script

    private ZombieAi movement; // Reference to the ZombieAi script

    public BoxCollider box; // Reference to the BoxCollider component

    [SerializeField]
    public float enemyHealth; // Health property of the enemy
  

    void Start()
    {
        movement = GetComponent<ZombieAi>(); // Get the ZombieAi component
        collision = GetComponent<ZombieCollision>(); // Get the ZombieCollision component

        AkSoundEngine.PostEvent("Play_Zombie_gargles_3", gameObject); // Play a sound event using AkSoundEngine
    }

    void Update()
    {
        // Update logic goes here
    }

    public void ReduceHealth(float reduceBy)
    {
        enemyHealth -= reduceBy; // Reduce enemy health by the specified amount

        if (enemyHealth <= 0)
        {
            DataStorage.instance.InceaseEnemyKilledCount(); // Increase the count of killed enemies in DataStorage
            agent.enabled = false; // Disable the NavMeshAgent component
            animator.SetBool("isDead", true); // Set the "isDead" parameter of the animator to true
            animator.SetBool("attack", false); // Set the "attack" parameter of the animator to false
            movement.enabled = false; // Disable the ZombieAi script
            AkSoundEngine.PostEvent("Play_Man_Dying", gameObject); // Play a sound event using AkSoundEngine
        }
    }
}
