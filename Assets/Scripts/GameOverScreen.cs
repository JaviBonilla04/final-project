using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void OnRetryButton()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.RestartGame();
    }

    public void OnMainMenuButton()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.LoadMainMenu();
    }
}