using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public static int WaterCount=3;
    public Animator animator;
    bool isJumping = false;
    [SerializeField] private int jumpCount = 0;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Start()
    {
        WaterCount = 3;
    }
void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if (IsGrounded()) { isJumping = false; jumpCount = 2; }
        if (Input.GetKeyDown("w") && jumpCount >0)
        {

            if (jumpCount == 1) {
                animator.SetBool("IsDoubleJumping", true);
            }
            
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
            jumpCount--;
        }

        if (Input.GetKeyDown("w") && rb.velocity.y > 0f )
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown("m") )
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene + 1, LoadSceneMode.Single);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("n"))
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene -1, LoadSceneMode.Single);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("r"))
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene , LoadSceneMode.Single);
            Time.timeScale = 1;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
       
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            PlayerMovement.WaterCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJumping", false);

        }
        if (collision.gameObject.CompareTag("Rain"))
        {
            if (PlayerMovement.WaterCount >0)
            {
                PlayerMovement.WaterCount--;
            }
        }
        if (collision.gameObject.CompareTag("PlayerDie"))
        {
            PlayerMovement.WaterCount = 0;
            //Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            PlayerMovement.WaterCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PlayerDie"))
        {
            PlayerMovement.WaterCount =0;
            //Destroy(collision.gameObject);
        }

    }
}