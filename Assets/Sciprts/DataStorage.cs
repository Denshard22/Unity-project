using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
    public static DataStorage instance; // Static reference to the DataStorage instance

    // Public variables
    public int requiredKills; // Number of kills required to achieve success
    public bool gameActive = true; // Flag indicating if the game is active

    // Serialized properties
    [field: SerializeField]
    public int health { get; set; } // Current health
    [field: SerializeField]
    public int maxHealth { get; set; } // Maximum health

    public int score { get; private set; } // Current score
    public int enemiesShot { get; set; } // Number of enemies shot
    public float playTime { get; private set; } // Total play time

    // Update method to track play time
    public void Update()
    {
        playTime += Time.deltaTime;
    }

    // Start method to initialize the DataStorage object
    public void Start()
    {
        // Ensure only one instance of DataStorage exists
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Keep the DataStorage object across scenes
        DontDestroyOnLoad(this.gameObject);
    }

    // Increase the score by 1
    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    // Restore health to its maximum value
    public void RestoreHealth()
    {
        health = maxHealth;
    }

    // Decrease health by the specified amount
    public void DecreaseHealth(int decreaseBy)
    {
        health -= decreaseBy;
        AkSoundEngine.PostEvent("Play_Zombie_Attack", gameObject);
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            DataStorage.instance.ResetGame();
            SceneManager.LoadScene("GameOver");
        }
    }

    // Increase the count of enemies shot
    public void InceaseEnemyKilledCount()
    {
        print(enemiesShot);
        enemiesShot++;
        if (enemiesShot == requiredKills)
        {
            //  SceneManager.LoadScene("Success");
        }
    }

    // Reset the game data
    public void ResetGame()
    {
        health = maxHealth;
        requiredKills = 0;
    }

    // Awake method to ensure the object is not destroyed on scene change
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
