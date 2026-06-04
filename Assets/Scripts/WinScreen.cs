using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = $"Score: {GameManager.Instance.score}";
            livesText.text = $"Lives: {GameManager.Instance.lives}";
        }
    }

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