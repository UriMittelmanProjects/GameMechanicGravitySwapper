using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float gravityScale = 5f;
    [SerializeField] private KeyCode gravitySwapKey = KeyCode.Space;

    private Rigidbody2D rb;
    private bool isGravityReversed = false;
    private Vector2 normalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f; // We'll use a standard scale since we're modifying global gravity
        normalGravity = Physics2D.gravity; // Store the initial gravity
    }

    void Update()
    {
        if (Input.GetKeyDown(gravitySwapKey))
        {
            SwapGravity();
        }
    }

    void SwapGravity()
    {
        isGravityReversed = !isGravityReversed;

        // Change global gravity direction
        Physics2D.gravity = isGravityReversed ?
            new Vector2(0, Mathf.Abs(normalGravity.y)) : // Upward gravity
            new Vector2(0, -Mathf.Abs(normalGravity.y)); // Downward gravity

        // Flip the player sprite to match gravity direction
        Vector3 playerScale = transform.localScale;
        playerScale.y *= -1;
        transform.localScale = playerScale;
    }
}