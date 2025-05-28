using UnityEngine;

public class DifficultyManager: MonoBehaviour
{
    public static DifficultyManager Instance;
    public enum DifficultyLevel { Easy, Medium, Hard, Insane, Endless }
    public DifficultyLevel CurrentDifficulty;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this instance persists across scenes
            Debug.Log("DifficultyManager initialized with difficulty: " + CurrentDifficulty);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("Another instance of DifficultyManager was found and destroyed. Only one instance should exist.");
        }
    }
}
