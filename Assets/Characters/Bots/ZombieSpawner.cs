using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;          // Zombie prefab to spawn
    public Transform[] spawnPoints;          // Spawn points
    public int initialZombies = 5;           // Zombies at the start
    public float spawnRate = 2f;             // Time between each spawn
    public int round = 1;                    // Current round
    public Camera mainCamera;                // Main camera reference

    private int zombiesToSpawn;              // Zombies per round
    private int zombiesRemaining;            // Zombies left to spawn this round

    void Start()
    {
        StartNewRound();
    }

    void StartNewRound()
    {
        zombiesToSpawn = initialZombies + (round - 1) * 2; // Increase zombies each round
        zombiesRemaining = zombiesToSpawn;
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (zombiesRemaining > 0)
        {
            Transform spawnPoint = GetValidSpawnPoint();
            if (spawnPoint != null)
            {
                Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
                zombiesRemaining--;
            }
            yield return new WaitForSeconds(spawnRate);
        }

        // Wait a few seconds before starting the next round
        yield return new WaitForSeconds(5f);
        round++;
        StartNewRound();
    }

    Transform GetValidSpawnPoint()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(spawnPoint.position);
            bool isInCameraView = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (!isInCameraView)
            {
                return spawnPoint;
            }
        }
        return null;
    }
}
