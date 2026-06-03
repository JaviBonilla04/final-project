using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void OnRetryButton()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.uiClickSFX);
        if (GameManager.Instance != null)
            GameManager.Instance.RestartGame();
    }

    public void OnMainMenuButton()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.uiClickSFX);
        if (GameManager.Instance != null)
            GameManager.Instance.LoadMainMenu();
    }
}