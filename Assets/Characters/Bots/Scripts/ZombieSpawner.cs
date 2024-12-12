using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;     // The zombie prefab to spawn
    public Vector2 spawnAreaSize = new Vector2(20f, 20f); // Width and height of the spawn area
    public Vector3 spawnAreaCenter = Vector3.zero;       // Center of the spawn area
    public float spawnRate = 5f;        // Time in seconds between spawns
    public int maxZombies = 10;         // Maximum number of zombies allowed in the game at once
    private int currentZombieCount = 0; // Tracks how many zombies are in the game
    public List<GameObject> zombieList = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnZombie", spawnRate, spawnRate);  // Repeatedly call the SpawnZombie method
    }
    private void Update()
    {
        
        currentZombieCount = zombieList.Count;
    }

    void SpawnZombie()
    {
        if (currentZombieCount < maxZombies)
        {
            // Generate a random position within the spawn area
            Vector2 randomPosition = GetRandomSpawnPosition();

            // Instantiate a new zombie at the random position
            GameObject newZombie = Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
            zombieList.Add(newZombie);

            // Increment the zombie count when a new one spawns
            currentZombieCount++;
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomY = spawnAreaCenter.y; // Fixed Y level for ground
        return new Vector3(spawnAreaCenter.x + randomX, randomY);
    }


    public void OnZombieDeath()
    {
        currentZombieCount--;   // Decrement zombie count when a zombie dies
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the spawn area in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter, new Vector3(spawnAreaSize.x, 1f, spawnAreaSize.y));
    }
}
