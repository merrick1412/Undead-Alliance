using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public GameObject zombiePrefab;

    // Round parameters
    public int currentRound = 1;
    public int zombiesPerRound = 5;
    public float timeBetweenRounds = 10f;
    public float spawnInterval = 1f;

    private int zombiesToSpawn;
    private bool isRoundActive;
    private float roundTimer;

    public UIManager uiManager;

    void Start()
    {
        spawnPoints.AddRange(FindObjectsOfType<SpawnPoint>());
        StartNewRound();
    }

    void Update()
    {
        if (!isRoundActive)
        {
            roundTimer += Time.deltaTime;
            if (roundTimer >= timeBetweenRounds)
            {
                StartNewRound();
            }
        }
    }

    void StartNewRound()
    {
        isRoundActive = true;
        zombiesToSpawn = zombiesPerRound + (currentRound - 1) * 5;
        uiManager.UpdateRoundText(currentRound); // Update the UI for the new round
        StartCoroutine(SpawnZombies());
    }

    System.Collections.IEnumerator SpawnZombies()
    {
        int spawnedZombies = 0;

        while (spawnedZombies < zombiesToSpawn)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                if (spawnedZombies >= zombiesToSpawn) break;

                SpawnZombieAtPoint(spawnPoint.transform);
                spawnedZombies++;

                yield return new WaitForSeconds(spawnInterval);
            }
        }

        EndRound();
    }

    void SpawnZombieAtPoint(Transform spawnPoint)
    {
        GameObject zombieInstance = Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);

        var zombieAI = zombieInstance.GetComponent<ZombieAI>();
        if (zombieAI != null)
        {
            zombieAI.SetDifficulty(currentRound); // Adjust AI difficulty for this round
        }
    }

    void EndRound()
    {
        isRoundActive = false;
        roundTimer = 0f;
        currentRound++;
    }
}
