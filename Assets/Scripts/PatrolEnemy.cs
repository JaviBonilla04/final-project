using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolEnemy : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform edgeCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.1f;

    private bool movingRight = true;
    private Rigidbody2D rb;

    private float lastFlipTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        bool groundAhead = Physics2D.Raycast(edgeCheck.position, Vector2.down, 0.5f, groundLayer);

        bool wallAhead = Physics2D.OverlapCircle(wallCheck.position, checkRadius, groundLayer);

        Debug.Log($"groundAhead: {groundAhead}, wallAhead: {wallAhead}");

        if (!groundAhead || wallAhead)
            Flip();

        rb.linearVelocity = new Vector2(movingRight ? moveSpeed : -moveSpeed, rb.linearVelocity.y);

    }

    private void Flip()
    {
        if (Time.time - lastFlipTime < 0.2f) return; 
        lastFlipTime = Time.time;
        movingRight = !movingRight;
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
            player.Die();
    }

    private void OnDrawGizmos()
    {
        if (edgeCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(edgeCheck.position, Vector2.down * 0.5f);
        }
        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(wallCheck.position, checkRadius);
        }
    }
}