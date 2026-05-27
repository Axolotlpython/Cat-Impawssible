using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    public float speed = 2f;
    public float rayDistance = 2f;
    private bool movingRight = true;

    public Transform groundDetection;
    public LayerMask groundLayer;

    void Update()
    {
        transform.Translate(Vector2.right * speed *  Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance, groundLayer);

        if (groundInfo.collider == false)
        {
            Flip();
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
        if (collision.gameObject.CompareTag("RatTurn"))
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
