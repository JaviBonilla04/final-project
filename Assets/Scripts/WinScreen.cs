using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public void OnPlayAgainButton()
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