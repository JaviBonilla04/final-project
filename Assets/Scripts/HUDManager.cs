using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Update()
    {
        if (GameManager.Instance == null) return;
        scoreText.text = $"Score: {GameManager.Instance.score}";
        livesText.text = $"Lives: {GameManager.Instance.lives}";
    }
}