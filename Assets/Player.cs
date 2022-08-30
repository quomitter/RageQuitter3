using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] float buttonTime = 0.3f;
    [SerializeField] float jumpAmount = 20;
    [SerializeField] float jumpTime;
    [SerializeField] bool jumping;


    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            jumpTime = 0; 
            
        }
        if (jumping)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            jumpTime += Time.deltaTime;
        }
        if (Input.GetButtonUp("Jump") | jumpTime > buttonTime)
        {
            jumping = false;
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y) ;

        Camera.main.transform.position = rb.transform.position + new Vector3(0,0,-10);
    }
}
