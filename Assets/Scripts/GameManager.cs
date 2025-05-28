using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int EnemiesToDefeat;
    public int enemiesDefeated = 0;
    public int score;
    public TMP_Text scoreText; // Reference to the UI Text component for displaying the score
    public TMP_Text finalScoreText; // Reference to the UI Text component for displaying the final score
    public TMP_Text highScoreText; // Reference to the UI Text component for displaying the high score

    void Start()
    {
        WinCondtionDifficulty(); // Set the win condition based on difficulty
    }
    public void EnemiesDefeated()
    {
        UpdateScore(1); // Update score when an enemy is defeated
        enemiesDefeated++;
        Debug.Log("Enemies defeated: " + enemiesDefeated);

        if (enemiesDefeated >= EnemiesToDefeat)
        {
            HighScoreUpdate(); // Update high score if necessary
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
    public void UpdateScore(int points) // Update the score and UI Text
    {
        score += points;
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score; // Update the UI Text with the new score
    }
    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore")) // Check if a high score exists in PlayerPrefs
        {
            if(score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score); // Update the high score if the current score is higher
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }

        // Try to find the TMP_Text components if they are not already assigned
        if (finalScoreText == null)
            finalScoreText = GameObject.Find("FinalScoreText")?.GetComponent<TMP_Text>(); // Find the Final Score Text component in the scene
        if (highScoreText == null)
            highScoreText = GameObject.Find("HighScoreText")?.GetComponent<TMP_Text>();// Find the High Score Text component in the scene

        if (finalScoreText != null)
            finalScoreText.text = score.ToString();// Update the Final Score Text with the current score
        else
            Debug.LogError("Final Score Text is not found in the scene.");

        if (highScoreText != null)
            highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();// Update the High Score Text with the saved high score
        else
            Debug.LogError("High Score Text is not found in the scene.");
    }
}
