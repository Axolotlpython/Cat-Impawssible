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

    public GameObject bulletPrefab;
    public UnityEngine.Transform _bulletSpawnPoint;


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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Check if the parent is flipped and adjust the direction
            float directionMultiplier = spriteRenderer.flipX ? -1f : 1f;
            Vector2 shootDir = _bulletSpawnPoint.right * directionMultiplier;

            rb.AddForce(shootDir * 1000);


        }
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            goundLayer
            );
        if ( isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("EndJump", false);
        }

        if (isGrounded == false)
        {
            animator.SetBool("EndJump", true);
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            animator.SetBool("Jump", true);
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
        if (isGrounded == false)
        {
            animator.SetBool("EndJump", true);
            animator.SetBool("IsRunning", false);
        }
        if (spriteRenderer.flipX == true)
        {
            gameObject.CompareTag("Yarn");
            spriteRenderer.flipX = true;
        }
    }

    public void OnJumpEnd()
    {
        animator.SetBool("Jump", false );
        animator.SetBool("EndJump", true );
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
