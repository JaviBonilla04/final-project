using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            // Por ahora solo destruye. El score lo conectamos en M4 con el GameManager.
            Destroy(gameObject);
        }
    }
}