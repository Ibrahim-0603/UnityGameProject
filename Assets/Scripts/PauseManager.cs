using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenuUI; // Reference to the pause menu UI GameObject
    private bool isPaused = false; // Track whether the game is paused

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false); // Hide the pause menu UI
        Time.timeScale = 1f; // Resume the game time
        isPaused = false; // Update the pause state
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f; // Pause the game time
        isPaused = true; // Update the pause state
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game time is resumed before loading a new scene
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
