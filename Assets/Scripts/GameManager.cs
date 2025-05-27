using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int EnemiesToDefeat;
    private int enemiesDefeated = 0;

    public void EnemiesDefeated()
    {
        enemiesDefeated++;
        Debug.Log("Enemies defeated: " + enemiesDefeated);

        if (enemiesDefeated >= EnemiesToDefeat)
        {
            WinGame();
        }
    }
    public void WinGame()
    {
        Debug.Log("You win! All enemies defeated.");
        SceneManager.LoadScene("WinScene"); // Load the win scene
    }
}
