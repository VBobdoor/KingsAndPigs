using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationMachine : MonoBehaviour
{
    private string horizontalDirectionAnimationVarName = "SpeedHorizontal";
    private string jumpAnimationVarName = "IsGrounded";
    private string attackAnimationVarName = "Attack";
    private string seatAnimationVarName = "Seat";
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public bool CheckViewDirection()
    {
        if (spriteRenderer.flipX == true)
            return false;
        else
            return true;
    }

    public void SetMoveAnimation(bool isGrounded, float horizontalDirection, bool isSeatButtonDown)
    {
        FlipCharacter(horizontalDirection);
        SetRunAndJumpAnimation(isGrounded, horizontalDirection);
        if (isSeatButtonDown)
        {
            SetSeatAnimation();
        }
    }

    private void FlipCharacter(float horizontalDirection)
    {
        if (horizontalDirection > 0)
            spriteRenderer.flipX = false;
        else if (horizontalDirection < 0)
            spriteRenderer.flipX = true;
    }

    
    private void SetRunAndJumpAnimation(bool isGrounded, float horizontalDirection)
    {
        animator.SetFloat(horizontalDirectionAnimationVarName, Mathf.Abs(horizontalDirection));
        animator.SetBool(jumpAnimationVarName, isGrounded);
    }

    public void SetAttackAnimation()
    {
        animator.SetTrigger(attackAnimationVarName);
    }

    public void SetSeatAnimation()
    {
        animator.SetTrigger(seatAnimationVarName);
    }
    
}
