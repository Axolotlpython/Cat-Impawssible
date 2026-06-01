using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RatMovement : MonoBehaviour
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

    private Rigidbody2D rb;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
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

            RaycastHit2D hitInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance, groundLayer);
            if (hitInfo.collider == false && player.position.y > transform.position.y)
            {
                // Jump to get on the higher object
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
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
        if (collision.CompareTag("PlayerFollow"))
        {
            isChasing = true;
            player = collision.transform;
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
