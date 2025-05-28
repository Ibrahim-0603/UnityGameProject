using UnityEngine;
using TMPro;
public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText; // Reference to the UI Text component for displaying the score
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void UpdateScore(int points)
    {
        score+= points;
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score; // Update the UI Text with the new score
    }
}
