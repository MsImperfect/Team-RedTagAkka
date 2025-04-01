using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab; // Assign the sprite prefab in the Inspector
    public int numberOfSprites = 5;
    public float spawnRadius = 5f;

    void Start()
    {
        for (int i = 0; i < numberOfSprites; i++)
        {
            SpawnSprite();
        }
    }

    void SpawnSprite()
    {
        Vector2 spawnPosition = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * spawnRadius;
        Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
    }
}