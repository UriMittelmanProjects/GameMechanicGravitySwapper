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
            LayerMask.GetMask("Ground") // Make sure your ground objects are on this layer
        );

        isGrounded = raycastHit.collider != null;

        // Determine gravity direction
        bool isGravityReversed = Physics2D.gravity.y > 0;

        // Jumping
        bool jumpKeyPressed = (isGravityReversed && Input.GetKeyDown(KeyCode.S)) ||
                              (!isGravityReversed && Input.GetKeyDown(KeyCode.W));

        if (jumpKeyPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Reset vertical velocity
            rb.AddForce(-Physics2D.gravity.normalized * jumpForce, ForceMode2D.Impulse);
        }

        // Smooth slide down walls if not grounded
        if (!isGrounded)
        {
            rb.linearVelocity += Physics2D.gravity.normalized * 0.5f * Time.deltaTime;
        }
    }

}