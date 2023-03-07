using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 10;
    public float jumps;

    [Header("Jump status")]
    public bool canJump; 
    public float jumpsLeft;

    Rigidbody2D rb;
    GroundDetector groundDetector;
    Walljump walljump;


    // Start is called before the first frame update
    void Start()
    {
        jumpsLeft = jumps;
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
        walljump = GetComponent<Walljump>();
    }

    // Update is called once per frame
    void Update()
    {

        canJump = jumpsLeft > 0;

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);

            jumpsLeft--;

            if (jumpsLeft == 0)
            {
                canJump = false;
            }

        } else if (!canJump && groundDetector.grounded)
        {
            jumpsLeft = jumps;
        }

    
    }
}
