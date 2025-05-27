using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab for the enemy to spawn
    public float spawnInterval = 8f; // Time interval between spawns
    public float spawnRangeY = 50f; // Range for random Y position
    public float spawnX = 100f; // Fixed X position for spawning

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }
    void SpawnEnemy()
    {
        // Calculate a random position within the specified range
        float yPosition = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(spawnX, yPosition);
        // Instantiate the meteor at the calculated position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
