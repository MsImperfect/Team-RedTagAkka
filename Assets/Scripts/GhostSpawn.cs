using System.Linq;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using System.Collections.Generic;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab; // Assign in Inspector

    void Start()
    {
        Invoke("Spawn", 2f);
    }

    public void Spawn()
    {
        // Check if there are planes detected
        if (PlaneManager.planes.Count == 0)
        {
            Debug.LogWarning("No AR planes detected yet!");
            return;
        }

        // Pick a random AR plane
        ARPlane p = PlaneManager.planes[Random.Range(0, PlaneManager.planes.Count)];

        // Get the plane size
        Vector2 extents = p.extents;
        float maxRad = Mathf.Max(extents.x, extents.y);

        // Generate a random spawn position within the plane
        Vector3 spawnPos = p.transform.position + (Random.insideUnitSphere * maxRad);
        spawnPos = new Vector3(spawnPos.x, p.transform.position.y+1, spawnPos.z); // Keep correct height

        // Instantiate the ghost at spawn position
        Instantiate(ghostPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Spawned ghost at: " + spawnPos);
    }
}
