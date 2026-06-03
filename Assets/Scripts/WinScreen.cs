using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public void OnPlayAgainButton()
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