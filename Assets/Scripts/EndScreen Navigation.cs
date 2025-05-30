using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenNavigation : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
    public void LoadGameScene()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
