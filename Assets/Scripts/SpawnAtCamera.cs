using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of prefabs to spawn
    public float minSpawnInterval = 0.5f; // Minimum time between spawns
    public float maxSpawnInterval = 2f;  // Maximum time between spawns
    public Vector3 spawnAreaMin;         // Minimum position for spawning
    public Vector3 spawnAreaMax;         // Maximum position for spawning

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Randomize spawn interval
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);

            // Choose a random object from the array
            int randomIndex = Random.Range(0, objectsToSpawn.Length);

            // Generate a random position within the defined area
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // Instantiate the object at the random position
            Instantiate(objectsToSpawn[randomIndex], randomPosition, Quaternion.identity);
        }
    }
}
