using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanelRat : MonoBehaviour
{
    public float speed = 2f;
    public float rayDistance = 2f;
    public float chaseSpeed = 2f;
    private bool movingRight = true;
    private bool isChasing = false;
    private Transform player;

    public float JumpForce = 5f;

    public Transform groundDetection;
    public LayerMask groundLayer;
    public float ceilingCheckDistance = 1f;

    private Rigidbody2D rb;

    public float jumpyDelay = 1f;
    public float jumpTimer;
    private bool isPerparingToJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance, groundLayer);
        bool isGrounded = groundCheck.collider != null;

        if (isChasing && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

            if (player.position.x > transform.position.x && !movingRight)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && movingRight)
            {
                Flip();
            }
            Vector2 dirVector = movingRight ? Vector2.right : Vector2.left;
            Vector2 jumpDir = (dirVector + Vector2.up).normalized; // Shoots up and forward
            RaycastHit2D jumpHit = Physics2D.Raycast(groundDetection.position, jumpDir, rayDistance, groundLayer);



            if (jumpHit.collider != null && player.position.y > transform.position.y && isGrounded)
            {

                if (!isPerparingToJump)
                {
                    isPerparingToJump = true;
                    jumpTimer = jumpyDelay;
                }
                else
                {
                    jumpTimer -= Time.deltaTime;
                    if (jumpTimer < 0)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                        isPerparingToJump = false;
                    }
                }

            }
            else
            {
                isPerparingToJump = false;
            }
        }

        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance, groundLayer);

            if (groundInfo.collider == false)
            {
                Flip();
            }
            isPerparingToJump = false;
        }

        /*if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RatTurn") && !isChasing)
        {
            Flip();
        }
      
    }

    void Flip()
    {
        movingRight = !movingRight;
        if (!movingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        /*if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }*/

    }
}
