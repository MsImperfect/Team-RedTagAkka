using UnityEngine;

public class SpawnAtCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToSpawn; // Prefab of the object to spawn (your ghost)

    [SerializeField]
    private int _numberOfObjects = 10; // Number of objects to spawn

    [SerializeField]
    private float _spawnSize = 5f; // Size of the sphere around the camera

    [SerializeField]
    private float _spawnDistance = 5f; 

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

        Vector3 spawnPosition;
        if (_spawnSize > 0)
        {
            spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * _spawnDistance + (Random.insideUnitSphere * _spawnSize);
        }
        else
        {
            spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * _spawnDistance;
        }
        GameObject spawnedObject = Instantiate(_objectToSpawn, spawnPosition, Quaternion.identity);
    }
}