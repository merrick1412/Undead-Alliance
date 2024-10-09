using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;     // The zombie prefab to spawn
    public Transform[] spawnPoints;     // Array of spawn points for the zombies
    public float spawnRate = 5f;        // Time in seconds between spawns
    public int maxZombies = 10;         // Maximum number of zombies allowed in the game at once
    private int currentZombieCount = 0; // Tracks how many zombies are in the game

    void Start()
    {
        InvokeRepeating("SpawnZombie", spawnRate, spawnRate);  // Repeatedly call the SpawnZombie method
    }

    void SpawnZombie()
    {
        if (currentZombieCount < maxZombies)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);   // Choose a random spawn point
            Instantiate(zombiePrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
            currentZombieCount++;   // Increment the zombie count when a new one spawns
        }
    }

    public void OnZombieDeath()
    {
        currentZombieCount--;   // Decrement zombie count when a zombie dies
    }
}
