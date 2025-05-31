using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SetEasy()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Easy;
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
            SceneManager.LoadScene("InfoScene");
        }

    }
    public void SetMedium()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Medium;
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
            SceneManager.LoadScene("InfoScene");
        }

    }
    public void SetHard()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Hard;
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
            SceneManager.LoadScene("InfoScene");
        }
    }
    public void SetInsane()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Insane;
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            SceneManager.LoadScene("InfoScene");
        }
    }
    public void SetEndless()
    {
        DifficultyManager.Instance.CurrentDifficulty = DifficultyManager.DifficultyLevel.Endless;
        if (SceneManager.GetActiveScene().name != "GameScene")
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
            SceneManager.LoadScene("InfoScene");
        }
    }
    public void Back()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        SceneManager.LoadScene("MainMenu"); 
    }
}
