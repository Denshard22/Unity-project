using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAi : MonoBehaviour
{
    public NavMeshAgent agent; // Reference to the NavMeshAgent component
    public Animator animator; // Reference to the Animator component
    public Transform player1; // Transform representing the player's position

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    private void Update()
    {
        // Check the distance between the zombie and the player
        if (Vector3.Distance(transform.position, player1.transform.position) > 7)
        {
            // Rotate the zombie to face the player
            transform.LookAt(player1);

            // Perform a raycast to check if there is an obstacle between the zombie and the player
            RaycastHit hit;
            var didHit = Physics.Raycast(transform.position, transform.forward, out hit, 40f);
            if (didHit && hit.collider.tag == "Player")
            {
                agent.enabled = true; // Enable the NavMeshAgent for pathfinding
                animator.SetBool("isWalking", true); // Set the walking animation state
            }
            else
            {
                agent.enabled = false; // Disable the NavMeshAgent
                animator.SetBool("isWalking", false); // Set the idle animation state
            }
        }
        else
        {
            agent.enabled = true; // Enable the NavMeshAgent
            animator.SetBool("isWalking", true); // Set the walking animation state
        }

        if (!DataStorage.instance.gameActive)
        {
            agent.enabled = false; // Disable the NavMeshAgent if the game is not active
            return;
        }

        if (player1 != null)
        {
            agent.enabled = true; // Enable the NavMeshAgent

            // Perform A* pathfinding to find the path to the player's position
            NavMeshPath path = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, player1.position, NavMesh.AllAreas, path))
            {
                // Set the calculated path to the NavMeshAgent
                agent.SetPath(path);
            }
        }
    }
}
