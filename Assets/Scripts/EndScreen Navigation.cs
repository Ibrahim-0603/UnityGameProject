using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenNavigation : MonoBehaviour
{
    public void LoadMainMenu()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
    public void LoadGameScene()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
            SceneManager.LoadScene("GameScene");
        }
    }
}
