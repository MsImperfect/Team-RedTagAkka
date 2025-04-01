using UnityEngine;

public class SpawnAtCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToSpawn; // Prefab of the object to spawn (your ghost)

    [SerializeField]
    private int _numberOfObjects = 10; // Number of objects to spawn

    [SerializeField]
    private float _spawnSize = 5f; // Size of the sphere around the camera

    void Start()
    {
        for (int i = 0; i < _numberOfObjects; i++)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main camera is null.  Make sure you have a camera tagged as 'MainCamera' in your scene.");
            return; // Exit if there's no main camera
        }

        Vector3 spawnPosition = Camera.main.transform.position + (Random.insideUnitSphere * _spawnSize);
        GameObject spawnedObject = Instantiate(_objectToSpawn, spawnPosition, Quaternion.identity);
    }
}