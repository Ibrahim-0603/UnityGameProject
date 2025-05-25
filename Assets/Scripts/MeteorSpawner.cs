using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // Prefab for the meteor to spawn
    public float spawnInterval = 4f; // Time interval between spawns
    public float spawnRangeY = 50f; // Range for random Y position
    public float spawnX = 100f; // Fixed X position for spawning

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f, spawnInterval);
    }
    void SpawnMeteor()
    {
        // Calculate a random position within the specified range
        float yPosition = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(spawnX, yPosition);
        // Instantiate the meteor at the calculated position
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }


}
