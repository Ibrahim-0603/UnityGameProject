using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab for the enemy to spawn
    public float spawnInterval = 10f; // Time interval between spawns
    public float spawnRangeY = 50f; // Range for random Y position
    public float spawnX = 100f; // Fixed X position for spawning

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRateDifficulty(); // Set the spawn rate based on difficulty
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }
    void SpawnEnemy()
    {
        // Calculate a random position within the specified range
        float yPosition = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(spawnX, yPosition);
        // Instantiate the meteor at the calculated position
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
    void SpawnRateDifficulty()
    {
        if(DifficultyManager.Instance != null)
        {
            switch (DifficultyManager.Instance.CurrentDifficulty)
            {
                case DifficultyManager.DifficultyLevel.Easy:
                    spawnInterval = 10f; // Easy difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Medium:
                    spawnInterval = 8f; // Medium difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Hard:
                    spawnInterval = 6f; // Hard difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Insane:
                    spawnInterval = 3f; // Insane difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Endless:
                    spawnInterval = 5f; // Endless difficulty spawn rate
                    break;
            }
        }
    }
}
