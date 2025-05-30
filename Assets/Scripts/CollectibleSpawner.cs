using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject HealtBoostPrefab; // Prefab for the health boost collectible
    public GameObject SpeedBoostPrefab; // Prefab for the speed boost collectible
    public GameObject DamageBoostPrefab; // Prefab for the damage boost collectible

    public float spawnInterval = 4f; // Time interval between spawns
    public float spawnRangeX = 100f; // Range for random Y position
    public float spawnY = 50f; // Fixed X position for spawning
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRateDifficulty(); // Set the spawn rate based on difficulty
        InvokeRepeating(nameof(SpawnCollectible), 1f, spawnInterval);
    }
    void SpawnCollectible()
    {
        // Calculate a random position within the specified range
        float xPosition = Random.Range(-spawnRangeX,0f);
        Vector2 spawnPosition = new Vector2(xPosition,spawnY);
        
        int randomIndex = Random.Range(0, 3); // Randomly choose collectible
        GameObject collectible = null;
        switch (randomIndex)
        {
            case 0:
                collectible = HealtBoostPrefab;
                break;
            case 1:
                collectible = SpeedBoostPrefab;
                break;
            case 2:
                collectible = DamageBoostPrefab;
                break;
        }
        if (collectible== null)
        {
            Debug.LogError("No collectible assigned for spawning!");
            return;
        }
        Instantiate(collectible, spawnPosition, Quaternion.identity);
    }

    void SpawnRateDifficulty()
    {
        if (DifficultyManager.Instance != null)
        {
            switch (DifficultyManager.Instance.CurrentDifficulty)
            {
                case DifficultyManager.DifficultyLevel.Easy:
                    spawnInterval = 10f; // Easy difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Medium:
                    spawnInterval = 6f; // Medium difficulty spawn rate
                    break;
                case DifficultyManager.DifficultyLevel.Hard:
                    spawnInterval = 3f; // Hard difficulty spawn rate
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
