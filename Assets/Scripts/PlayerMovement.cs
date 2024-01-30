using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Search;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    //VARIABLES
    private float vertical;
    private float horizontal;

    public float climbingSpeed = 3f;
    public float speed = 4f;
    private float speedMulti = 1.5f;
    private float airSpeedMulti = 1.3f;
    private float climpingSpeedMulti = 1.2f;

    public float maxStamina;
    public float stamina;
    public float runCost;
    public float chargeRate;
    private Coroutine recharge;
    private float tiredMulti = .5f;

    public float FallMultiplier;
    public float jumMulti;
    public float jumpingPower = 12f;

    private bool isTired;
    private bool isRunning;
    private bool isLadder;
    private bool isClimbing;
    private bool isFastClimbing;
    private bool isFacingRight = true;

    private GameObject currentOneWayPlatform;
    private GameObject currentOneWayLadder;
    private GameObject currentOneWayStair;

    //REFERENCES
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D playerCollider;
    private void Update()
    {
        //CALCULATING JUMPING INPUT
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Jump") && IsGrounded() && !isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f && !isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
        if(rb.velocity.y < 0f && !isClimbing)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        Flip();

        //CALCULATING CLIMBING INPUT
        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        if (isClimbing && (Input.GetKey(KeyCode.LeftShift)))
        {
            isFastClimbing = true;
        }
        else
        {
            isFastClimbing = false;
        }

        //CALCULATING RUNNING INPUT
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        //STAMINA
        if((isRunning && !isFastClimbing))
        {
            stamina -= runCost * Time.deltaTime;
            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(rechargeStamina());
        }
        if (stamina < 0) stamina = 0;
        if (stamina == 0)
        //stamina fill amount should go here
        {
            isTired = true;
        }
        else
        {
            isTired = false;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollisionPlatform());
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentOneWayLadder != null)
            {
                StartCoroutine(DisableCollisionLadder());
            }
        }


        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentOneWayStair != null)
            {
                StartCoroutine(DisableCollisionStair());
            }
        }
    }


    private void FixedUpdate()
    {
        //NORMAL SPEED
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //CLIMBING
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed);
        }
        else
        {
            rb.gravityScale = 2f;
        }

        if(isFastClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed * climpingSpeedMulti);
        }

        //RUNNING SPEED  
        if((isRunning) && IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed * speedMulti, rb.velocity.y);
        }
        if((isRunning) && !IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed * airSpeedMulti, rb.velocity.y);
        }

        //STAMINA 
        if(isTired)
        {
            rb.velocity = new Vector2(horizontal * speed * tiredMulti, rb.velocity.y);
        }
    }

    //DIRECTION
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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
        return Physics2D.OverlapCircle(groundCheck.position, .2f, groundLayer);
    }

    //CLIMBING COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWay"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
        if(collision.gameObject.CompareTag("OneWayLadder"))
        {
            currentOneWayLadder = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("OneWayStair"))
        {
            currentOneWayStair = collision.gameObject;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWay"))
        {
            currentOneWayPlatform = null;
        }

        if(collision.gameObject.CompareTag("OneWayLadder"))
        {
            currentOneWayLadder = null;
        }

        if (collision.gameObject.CompareTag("OneWayStair"))
        {
            currentOneWayStair = null;
        }
    }





    //STAMINA RECHARGE
    private IEnumerator rechargeStamina()
        {
            yield return new WaitForSeconds(1f);
            while (stamina < maxStamina && (!isRunning))
            {
                stamina += chargeRate / 10f;
                if (stamina > maxStamina) stamina = maxStamina;
                //stamina fill amount should go here
                yield return new WaitForSeconds(.1f);
            }
        }

    private IEnumerator DisableCollisionPlatform()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private IEnumerator DisableCollisionLadder()
    {
        BoxCollider2D platformCollider = currentOneWayLadder.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private IEnumerator DisableCollisionStair()
    {
        BoxCollider2D platformCollider = currentOneWayStair.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}

    
