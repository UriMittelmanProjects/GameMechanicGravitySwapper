using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private GravityController gravityController;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gravityController = GetComponent<GravityController>();
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Check if player is grounded
        float extraHeightCheck = 0.1f;
        Vector2 raycastDirection = Physics2D.gravity.normalized;
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            raycastDirection,
            extraHeightCheck,
            LayerMask.GetMask("Default")
        );

        isGrounded = raycastHit.collider != null;

        // Determine if gravity is reversed (pointing upward)
        bool isGravityReversed = Physics2D.gravity.y > 0;

        // Jump logic based on gravity direction
        if (isGrounded)
        {
            // Use W to jump when gravity is normal (downward)
            // Use S to jump when gravity is reversed (upward)
            if ((isGravityReversed && Input.GetKeyDown(KeyCode.S)) ||
                (!isGravityReversed && Input.GetKeyDown(KeyCode.W)))
            {
                // Jump in opposite direction of gravity
                rb.AddForce(-Physics2D.gravity.normalized * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}