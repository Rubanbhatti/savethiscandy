using System.Collections;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab; // The prefab of the ant to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public float initialSpawnInterval = 5f; // Initial time between spawns
    public float initialAntLifetime = 20f; // Initial duration before ants are destroyed
    public float intervalChangeTime = 25f; // Time interval to change spawn interval and ant lifetime

    private float spawnInterval;
    private float antLifetime;

    private void Start()
    {
        spawnInterval = initialSpawnInterval;
        antLifetime = initialAntLifetime;

        // Start the coroutine for spawning ants
        StartCoroutine(SpawnAnts());
        StartCoroutine(ChangeIntervalAndLifetime());
    }

    IEnumerator SpawnAnts()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newAnt = Instantiate(antPrefab, randomSpawnPoint.position, Quaternion.identity);

            Destroy(newAnt, antLifetime);
        }
    }

    IEnumerator ChangeIntervalAndLifetime()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalChangeTime);

            DecreaseSpawnInterval();
            IncreaseAntLifetime();
        }
    }

    private void DecreaseSpawnInterval()
    {
        spawnInterval = Mathf.Max(0.4f, spawnInterval - 0.3f); // Decrease spawn interval but keep it above 1 second
    }

    private void IncreaseAntLifetime()
    {
        antLifetime += 2.5f; // Increase ant lifetime by 5 seconds
    }
}
