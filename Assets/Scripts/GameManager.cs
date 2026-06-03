using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void PlayerDied()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void StartGame()
    {
        score = 0;
        lives = 3;
        SceneManager.LoadScene("Level1");
    }

    public void RestartGame()
    {
        score = 0;
        lives = 3;
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}