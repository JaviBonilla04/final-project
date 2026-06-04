using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private float jumpCutMultiplier = 0.5f;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float jumpBufferTime = 0.15f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.8f, 0.1f);
    [SerializeField] private LayerMask groundLayer;

    [Header("Respawn")]
    [SerializeField] private Transform spawnPoint;

    private Rigidbody2D rb;
    private InputAction moveAction;
    private InputAction jumpAction;
    private bool isGrounded;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private float deathCooldown = 0f;


    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {

        if (deathCooldown > 0f) deathCooldown -= Time.deltaTime;

        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        if (jumpAction.WasPressedThisFrame())
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;

            AudioManager.Instance?.PlaySFX(AudioManager.Instance.jumpSFX);

        }

        if (jumpAction.WasReleasedThisFrame() && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * jumpCutMultiplier);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        // Flip del sprite según dirección:
        if (horizontalInput > 0.01f)
            spriteRenderer.flipX = false;
        else if (horizontalInput < -0.01f)
            spriteRenderer.flipX = true;
    }

    public void Die()
    {
        if (deathCooldown > 0f) return; // ignora si ya murió recientemente
        deathCooldown = 0.3f;

        rb.linearVelocity = Vector2.zero;
        transform.position = spawnPoint.position;

        AudioManager.Instance?.PlaySFX(AudioManager.Instance.dieSFX);

        if (GameManager.Instance != null)
            GameManager.Instance.PlayerDied();
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}