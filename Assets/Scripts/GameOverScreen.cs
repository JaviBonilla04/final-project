using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        if (GameManager.Instance != null)
            scoreText.text = $"Score: {GameManager.Instance.score}";
    }

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