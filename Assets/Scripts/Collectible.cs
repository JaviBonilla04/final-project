using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(value);
            Destroy(gameObject);
        }
    }
}