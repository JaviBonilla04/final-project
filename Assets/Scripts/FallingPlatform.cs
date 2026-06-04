using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 0.5f;
    [SerializeField] private float respawnTime = 3f;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private bool isFalling;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null && !isFalling)
        {
            // Solo activa si player encima
            if (other.transform.position.y > transform.position.y)
                StartCoroutine(FallRoutine());
        }
    }

    private IEnumerator FallRoutine()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }

    private void Respawn()
    {
        rb.linearVelocity = Vector2.zero; 
        rb.bodyType = RigidbodyType2D.Static; 
        transform.position = startPosition;
        isFalling = false;
    }
}