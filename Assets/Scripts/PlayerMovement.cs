using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    //Moving
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;

    //Dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 18f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    //Wall Sliding & Jumping
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.2f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    public Animator animator;
    public bool aliveTrig = true;
    public bool alive = true;


    void Update()
    {

        if (isDashing || !alive)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if(IsGrounded())
        {
            animator.SetBool("IsGround", true);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("IsGround", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        //hold for higher jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        if(aliveTrig == false)
        {
            
            StartCoroutine(DeathAnim());


        }

        //Debug.DrawRay(groundCheck.position, Vector2.down * 0.2f, Color.red); //Ground Checker for Visualization

        WallSlide();
        WallJump();
        if (!isWallJumping)
        {
            Flip();
        }
        
    }

    private void FixedUpdate()
    {
        if (isDashing || !alive)
        {
            return;
        }

        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, wallLayer);
    }

    private void WallSlide()
    {
        //if (IsWalled() && !IsGrounded() && horizontal != 0f)
        if (IsWalled() && !IsGrounded())
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsWalled", true);
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            animator.SetBool("IsWalled", false);
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DeathAnim()
    {
        alive = false;
        animator.SetBool("Dead", true);
        
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Dead", false);
        yield return new WaitForSeconds(0.6f);
        alive = true;
    }
}
