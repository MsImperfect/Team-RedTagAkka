using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnRadius = 10f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 4f;
    public float moveSpeed = 5f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Automatically assign the main camera

        if (mainCamera == null)
        {
            Debug.LogError("No Main Camera found! Make sure your camera is tagged 'MainCamera'.");
            return;
        }

        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            // Generate a random spawn position around the camera
            float spawnDistance = Random.Range(3, spawnRadius);
            Vector3 randomOffset = Random.insideUnitSphere * spawnDistance;
            randomOffset.y = Mathf.Abs(randomOffset.y); // Prevents spawning underground

            Vector3 spawnPosition = mainCamera.transform.position + randomOffset;

            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // Start moving the object towards the camera
            StartCoroutine(MoveTowardsCamera(spawnedObject));
        }
    }

    IEnumerator MoveTowardsCamera(GameObject obj)
    {
        while (obj != null)
        {
            Vector3 direction = (mainCamera.transform.position - obj.transform.position).normalized;
            obj.transform.position += direction * moveSpeed * Time.deltaTime;
            yield return null; // Wait for the next frame
        }
    }
}
