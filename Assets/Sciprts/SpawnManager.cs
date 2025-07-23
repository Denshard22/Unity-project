using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab to be spawned
    public Transform spawnPoint; // Position and rotation where the prefab should be spawned
    public float spawnInterval = 3f; // Interval between spawns
    public int maxSpawnCount = 15; // Maximum number of spawns

    private float timer = 0f; // Timer to track the spawn interval
    private int spawnCount = 0; // Number of spawns that have occurred
    public Transform player; // Reference to the player's transform

    private void Update()
    {
        timer += Time.deltaTime; // Increase the timer based on real-time passed

        if (timer >= spawnInterval && spawnCount < maxSpawnCount)
        {
            SpawnPrefab(); // Call the method to spawn the prefab
            timer = 0f; // Reset the timer
        }
    }

    private void SpawnPrefab()
    {
        var tmp = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation); // Instantiate the prefab at the spawn point
        tmp.GetComponent<ZombieAi>().player1 = player; // Set the player reference on the spawned prefab
        spawnCount++; // Increase the spawn count
    }
}