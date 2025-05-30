using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int EnemiesToDefeat;
    public int enemiesDefeated = 0;
    public PointManager pointManager;
    public static GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        WinCondtionDifficulty(); // Set the win condition based on difficulty
    }
    public void EnemiesDefeated()
    {
        pointManager.UpdateScore(1); // Update score when an enemy is defeated
        enemiesDefeated++;
        Debug.Log("Enemies defeated: " + enemiesDefeated);

        if (enemiesDefeated >= EnemiesToDefeat)
        {
            PlayerPrefs.SetInt("FinalScore", enemiesDefeated);
            WinGame();
        }
    }
    public void WinGame()
    {
        Debug.Log("You win! All enemies defeated.");
        SceneManager.LoadScene("WinScene"); // Load the win scene
    }
    
    void WinCondtionDifficulty() // Set the win condition based on difficulty level
    {
        if(DifficultyManager.Instance != null)
        {
            switch (DifficultyManager.Instance.CurrentDifficulty)
            {
                case DifficultyManager.DifficultyLevel.Easy:
                    EnemiesToDefeat = 5; // Easy difficulty win condition
                    break;
                case DifficultyManager.DifficultyLevel.Medium:
                    EnemiesToDefeat = 10; // Medium difficulty win condition
                    break;
                case DifficultyManager.DifficultyLevel.Hard:
                    EnemiesToDefeat = 15; // Hard difficulty win condition
                    break;
                case DifficultyManager.DifficultyLevel.Insane:
                    EnemiesToDefeat = 30; // Insane difficulty win condition
                    break;
                case DifficultyManager.DifficultyLevel.Endless:
                    EnemiesToDefeat = 99999; // Endless difficulty win condition
                    break;
            }
        }
    }
    
}