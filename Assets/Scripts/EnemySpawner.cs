using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject basicEnemyPrefab; // Prefab for the enemy to spawn
    public GameObject fastEnemyPrefab;
    public GameObject tankEnemyPrefab;

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
        int randomIndex = Random.Range(0, 3); // Randomly choose an enemy type
        GameObject enemyToSpawn = null;
        switch(randomIndex)
        {
            case 0:
                enemyToSpawn = basicEnemyPrefab; // Basic enemy
                break;
            case 1:
                enemyToSpawn = fastEnemyPrefab; // Fast enemy
                break;
            case 2:
                enemyToSpawn = tankEnemyPrefab; // Tank enemy
                break;
        }
        if (enemyToSpawn == null)
        {
            Debug.LogError("No enemy prefab assigned for spawning!");
            return;
        }

        Instantiate(enemyToSpawn, spawnPosition, enemyToSpawn.transform.rotation);
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
