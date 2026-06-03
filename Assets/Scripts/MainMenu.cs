using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.uiClickSFX);
        if (GameManager.Instance != null)
            GameManager.Instance.StartGame();
        else
            SceneManager.LoadScene("Level1"); // fallback
    }

    public void OnQuitButton()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.uiClickSFX);
        if (GameManager.Instance != null)
            GameManager.Instance.QuitGame();
        else
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}