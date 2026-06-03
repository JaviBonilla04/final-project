using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("LEVEL COMPLETE!");
            // En M3 conectamos con GameManager.Instance.WinGame()
            AudioManager.Instance?.PlaySFX(AudioManager.Instance.winSFX);
            if (GameManager.Instance != null)
                GameManager.Instance.WinGame();
        }
    }
}