using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnRadius = 10f;
    public float minLifetime = 2f;
    public float maxLifetime = 5f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 4f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {

            float waitTime = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            float sqawnRadius = UnityEngine.Random.Range(1, spawnRadius);
            //Vector3 spawnPosition = transform.position + (Vector3)(UnityEngine.Random.insideUnitCircle * sqawnRadius);
            Vector3 spawnPosition = (Vector3)(UnityEngine.Random.insideUnitCircle * sqawnRadius);
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);


            float lifetime = UnityEngine.Random.Range(1, maxLifetime);


            Destroy(spawnedObject, lifetime);
        }
    }
}
