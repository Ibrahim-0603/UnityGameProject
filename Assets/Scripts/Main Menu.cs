using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.mainMenuMusic);
    }
    public void StartGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        SceneManager.LoadScene("DifficultyScene");
    }
    public void Settings()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        SceneManager.LoadScene("Settings");
    }
    public void Quitgame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
