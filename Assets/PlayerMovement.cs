using UnityEngine;
using UnityEngine.tvOS;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    private Rigidbody2D rb;
    private bool isGrounded; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (moveInput < 0) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
    }



    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
        if (collision.collider.CompareTag("Obstacle"))
        {
            //Time.timeScale = 0;
            Debug.Log("Trò chơi đã dừng do va chạm với chướng ngại vật!");
        }
        if (collision.collider.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Touch Apple");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
