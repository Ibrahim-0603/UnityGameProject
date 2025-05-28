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
        SpawnRateDifficulty(); // Set the spawn rate based on difficulty
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
    void SpawnRateDifficulty()
    {
        if (DifficultyManager.Instance != null)
        {
            switch (DifficultyManager.Instance.CurrentDifficulty)
            {
                case DifficultyManager.DifficultyLevel.Easy:
                    spawnInterval = 4f; // Easy difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Medium:
                    spawnInterval = 3.5f; // Medium difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Hard:
                    spawnInterval = 2.5f; // Hard difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Insane:
                    spawnInterval = 1.5f; // Insane difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Endless:
                    spawnInterval = 3f; // Endless difficulty spawn rate
                    break;
            }
        }
    }
}
