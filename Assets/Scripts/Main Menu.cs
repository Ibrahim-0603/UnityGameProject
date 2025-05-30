using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DifficultyScene");
    }
    public void Quitgame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
