using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SetEasy()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Easy;
        SceneManager.LoadScene("GameScene"); 
    }
    public void SetMedium()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Medium;
        SceneManager.LoadScene("GameScene");
    }
    public void SetHard()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Hard;
        SceneManager.LoadScene("GameScene");
    }
    public void SetInsane()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Insane;
        SceneManager.LoadScene("GameScene");
    }
    public void SetEndless()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Endless;
        SceneManager.LoadScene("GameScene");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
