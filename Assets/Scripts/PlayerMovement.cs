using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AnimationMachine), typeof(PlayerSeatAndGoThroughPlatform))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speedHorizontal;

    [Header("Settigs")]
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckColliderRadius = 1f;

    private PlayerSeatAndGoThroughPlatform playerSeatAndGothroughPlatform;
    private Rigidbody2D rb;
    private AnimationMachine animationMachine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationMachine = GetComponent<AnimationMachine>();
        playerSeatAndGothroughPlatform = GetComponent<PlayerSeatAndGoThroughPlatform>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckColliderRadius);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckColliderRadius, groundMask);
    }

    public void Move(float horizontalDirection, bool isJumpButtonDown, bool isSeatButtonDown)
    {
        if (!isSeatButtonDown && isJumpButtonDown && isGrounded)
            Jump();
        else if (isSeatButtonDown && isJumpButtonDown && isGrounded)
            playerSeatAndGothroughPlatform.GoThroughPlatform();

        HorizontalMovement(horizontalDirection);
        animationMachine.SetMoveAnimation(isGrounded, horizontalDirection, isSeatButtonDown);

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HorizontalMovement(float horizontalDirection)
    {
        rb.velocity = new Vector2(speedHorizontal * horizontalDirection, rb.velocity.y);
    }

}

