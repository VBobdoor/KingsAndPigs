using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool isBlocked = false;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform leftGroundCheckPoint;
    [SerializeField] private Transform rightGroundCheckPoint;
    [SerializeField] private Transform leftWallCheckPoint;
    [SerializeField] private Transform rightWallCheckPoint;

    [SerializeField] private float groundCheckColliderRadius = 0.2f;

    [SerializeField] private float speedHorizontal;

    private float FlipDirectionCooldown = 3f;
    private int currentDirection = -1;
    private bool ableToMove = true;
    private int stop = 0;

    private Animator animationMachine;
    private Rigidbody2D enemyRigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("Death"))
        {
            ableToMove = false;
            HorizontalMovement(stop);
        }
            

        if(ableToMove)
            Move();
    }

    private void Move()
    {
        Transform groundCheckPoint = GetCheckGroundPoint();
        Transform wallCheckPoint = GetCheckWallPoint();
        currentDirection = GetViewDirection();

        isBlocked = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckColliderRadius, groundMask);
        isBlocked = isBlocked && !Physics2D.OverlapCircle(wallCheckPoint.position, groundCheckColliderRadius, groundMask);
        CheckAbleToMove();
    }

    private Transform GetCheckGroundPoint()
    {
        if (spriteRenderer.flipX)
            return rightGroundCheckPoint;
        else
            return leftGroundCheckPoint;
    }

    private Transform GetCheckWallPoint()
    {
        if (spriteRenderer.flipX)
            return rightWallCheckPoint;
        else
            return leftWallCheckPoint;
    }

    private int GetViewDirection()
    {
        if (spriteRenderer.flipX)
            return 1;
        else
            return -1;
    }



    private void CheckAbleToMove()
    {
        if (isBlocked)
        {
            HorizontalMovement(currentDirection);
        }
        else
        {
            StartCoroutine(SetFlipDirectionCooldown());
            currentDirection *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            HorizontalMovement(stop);
        }
    }  

    private void HorizontalMovement(float horizontalDirection)
    {
        enemyRigidbody.velocity = new Vector2(speedHorizontal * horizontalDirection, enemyRigidbody.velocity.y);
    }

    private IEnumerator SetFlipDirectionCooldown()
    {
        ableToMove = false;
        animator.SetBool("IsRunning", false);
        yield return new WaitForSeconds(FlipDirectionCooldown);
        animator.SetBool("IsRunning", true);
        ableToMove = true;
    }
}
