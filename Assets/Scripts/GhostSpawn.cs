using System.Linq;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using System.Collections.Generic;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab; // Assign in Inspector

    private int spawnedGhosts = 0;
    private List<GameObject> gameObjects = new List<GameObject>();

    private int maxGhosts = 5;
    public float targetSize = 5.0f;

    bool canSpawn = false;

    void Start()
    {

    }

    void Update()
    {
        if (canSpawn)
        {
            return;
        }
        float totalSize = 0;
        // Find valid AR planes that meet size requirements
        foreach (ARPlane p in PlaneManager.planes)
        {
            Vector2 size = p.size;
            totalSize += size.x*size.y;
        }
        if (totalSize >= targetSize)
        {
            canSpawn = true;
            Spawn();
        }

    }

    public void Spawn()
    {
        // Check if there are planes detected
        if (PlaneManager.planes.Count == 0)
        {
            Debug.LogWarning("No AR planes detected yet!");
            Invoke("Spawn", 10f);
            return;
        }

        // Pick a random AR plane
        ARPlane p = PlaneManager.planes[Random.Range(0, PlaneManager.planes.Count)];

        // Get the plane size
        Vector2 extents = p.extents;
        float maxRad = Mathf.Max(extents.x, extents.y);

        // Generate a random spawn position within the plane
        Vector3 spawnPos = (Vector3)p.centerInPlaneSpace + (Random.insideUnitSphere * maxRad);
        spawnPos = new Vector3(spawnPos.x, p.transform.position.y + 1, spawnPos.z + 10); // Keep correct height

        // Instantiate the ghost at spawn position
        gameObjects.Add(Instantiate(ghostPrefab, spawnPos, Quaternion.identity));
        spawnedGhosts++;
        Debug.Log("Spawned ghost at: " + spawnPos);
        if (spawnedGhosts < maxGhosts)
        {
            Spawn();
        }
    }
}