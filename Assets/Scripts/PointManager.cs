using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText; // Reference to the UI Text component for displaying the score
    public TMP_Text finalScoreText; // Reference to the UI Text component for displaying the final score
    public TMP_Text highScoreText; // Reference to the UI Text component for displaying the high score

    void Awake()
    {
        Debug.Log("PointManager Awake. scoreText: " + scoreText?.name);
    }

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "WinScene" || currentScene == "GameOverScene")
        {
            score = PlayerPrefs.GetInt("FinalScore", 0);
            HighScoreUpdate();
        }
        GameObject obj = GameObject.Find("scoreText");
        if (obj != null)
        {
            scoreText = obj.GetComponent<TMP_Text>();
            Debug.Log("Scoretext found and assigned at runtime");
        }
        else
        {
            Debug.LogError("Scoretext not found in scene");
        }
        
    }
    public void UpdateScore(int points) // Update the score and UI Text
    {
        score += points;
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score; // Update the UI Text with the new score in game scene
    }
    public void HighScoreUpdate()
    {

        int savedHigh = PlayerPrefs.GetInt("SavedHighScore", 0);

        if (score > savedHigh)
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
            savedHigh = score;
        }

        // Find UI elements if not assigned
        if (finalScoreText == null)
            finalScoreText = GameObject.Find("FinalScoreText")?.GetComponent<TMP_Text>();
        if (highScoreText == null)
            highScoreText = GameObject.Find("HighScoreText")?.GetComponent<TMP_Text>();

        // Update UI
        if (finalScoreText != null)
            finalScoreText.text = "Score: " + score;
        else
            Debug.LogError("FinalScoreText not found in scene.");

        if (highScoreText != null)
            highScoreText.text = "High Score: " + savedHigh;
        else
            Debug.LogError("HighScoreText not found in scene.");
    }

}
