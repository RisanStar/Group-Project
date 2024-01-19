using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private float climbingSpeed = 3f;
    private float speed = 4f;
    private float speedMulti = 1.5f;
    private float airSpeedMulti = 1.3f;
    public float stamina;
    public float FallMultiplier;
    public float jumMulti;
    private float jumpingPower = 10f;
    private bool isRunning;
    private bool isLadder;
    private bool isClimbing;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Update()
    {
        //CALCULATING JUMPING INPUT
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && IsGrounded() && !isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && !isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (rb.velocity.y < 0f && !isClimbing)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        Flip();

        //CALCULATING CLIMBING INPUT
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        //CALCULATING RUNNING INPUT
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        //NORMAL SPEED
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //CLIMBING
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed);
        }
        else
        {
            rb.gravityScale = 2f;
        }

        //RUNNING SPEED  
        if ((isRunning) && IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed * speedMulti, rb.velocity.y);
        }
        if ((isRunning) && !IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed * airSpeedMulti, rb.velocity.y);
        }

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

    //GROUND CHECKER
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //CLIMBING COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}