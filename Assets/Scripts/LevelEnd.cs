using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private string nextScene = "WinScene";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            AudioManager.Instance?.PlaySFX(AudioManager.Instance.winSFX);
            SceneManager.LoadScene(nextScene);
        }
    }
}