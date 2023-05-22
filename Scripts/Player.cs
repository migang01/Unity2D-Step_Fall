using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 10;
    public float jumpForce = 6;
    private Rigidbody2D rb;
    private Animator anim;
    public Transform groundPos;

    public bool isJumping;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isGrounded;

    public static bool isOver;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("takeOf");
            isJumping = true;
            Audio.JumpSoundPlay();
            
            rb.velocity = Vector2.up * jumpForce;
        }


        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);

        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;

        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);

        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.Pause();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Normal"))
        {
            speed = 5;
        }

        if(collision.CompareTag("Danger"))
        {
            speed = 2.5f;
            
        }

        if(collision.CompareTag("Slippery"))
        {
            speed = 10f;
            
        }

        if(collision.CompareTag("Remove"))
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger"))
        {
            speed = 5;
            if (isJumping == true)
            {
                Audio.SlowJumpPlay();
            }
        }

        if (collision.CompareTag("Slippery"))
        {
            speed = 5;
            if (isJumping == true)
            {
                Audio.SlipperyJumpSoundPlay();
            }
        }

    }


}

