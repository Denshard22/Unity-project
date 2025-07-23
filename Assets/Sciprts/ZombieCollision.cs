using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    [SerializeField] private int decreasePlayerHealthBy; // Amount to decrease player's health
    [SerializeField] Animator animator; // Reference to the Animator component
    public bool canDamagePlayer = true; // Flag to control whether the zombie can damage the player

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDamagePlayer)
        {
            animator.SetBool("attack", true); // Set the "attack" parameter in the Animator to trigger the attack animation
            DataStorage.instance.DecreaseHealth(decreasePlayerHealthBy); // Decrease the player's health using the DataStorage class
        }
    }
}
