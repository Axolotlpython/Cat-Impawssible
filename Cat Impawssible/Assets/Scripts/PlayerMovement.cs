using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float jumpForce = 20f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask goundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    AudioSource audioSource;

    [SerializeField] private Animator animator;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            goundLayer
            );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            audioSource.Play();
            
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Sit", true);
            animator.SetBool("IsRunning", false);
        }
       /* else
        {
            animator.SetBool("Sit", false);
        }*/

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("Sit", false);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("Sit", false);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("IsRunning", false);
            
        }
    }



    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

}
