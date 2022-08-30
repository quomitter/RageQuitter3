using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rbSprite;

    [SerializeField] Transform groundCheck;
    [SerializeField] Transform dustPos;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] GameObject feetDust; 

    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] float buttonTime = 0.3f;
    [SerializeField] float jumpAmount = 20;
    [SerializeField] float jumpTime;
    [SerializeField] bool jumping;
    [SerializeField] bool isGrounded;
    [SerializeField] int jumpCounter;
    [SerializeField] bool canDoubleJump;


    // Start is called before the first frame update
    void Start()
    {
        canDoubleJump = true; 
        jumpCounter = 0; 
        isGrounded = false;
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>(); 


    }

    // Update is called once per frame
    void Update()
    {
        if (canDoubleJump) 
        { 
            if (Input.GetButtonDown("Jump") && (isGrounded || jumpCounter < 1))
            { 
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumpCounter++;

            }
        }
        if (!canDoubleJump)
        {
            if (Input.GetButtonDown("Jump") && (isGrounded || jumpCounter < 0))
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumpCounter++;

            }
        }
        if (isGrounded)
        {
            jumpCounter = 0;
        }
        if (Input.GetButtonUp("Jump") | jumpTime > buttonTime)
        {
            jumping = false;
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y) ;
        if(rb.velocity.x < 0f)
        {
            rbSprite.flipX = true;
            Instantiate(feetDust, dustPos.transform.position + new Vector3(0.7f, 0, 0), dustPos.transform.rotation);
        }
        else
        {
            rbSprite.flipX = false;
            Instantiate(feetDust, dustPos.transform.position, dustPos.transform.rotation);
        }

        Camera.main.transform.position = rb.transform.position + new Vector3(0,0,-10);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
    }
}
