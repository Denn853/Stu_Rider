using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 10;
    public float jumps;
    public Vector2 wallJumpPower;

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

            if (GetComponent<Walljump>().isInWall)
            {
                if (GetComponent<HorizontalMovement>().dir == HorizontalMovement.Directions.RIGHT)
                {
                    if (wallJumpPower.x > 0)
                        wallJumpPower.x *= -1;

                    rb.AddForce(wallJumpPower);
                    GetComponent<HorizontalMovement>().dir = HorizontalMovement.Directions.LEFT;
                } 
                else
                {
                    if (wallJumpPower.x < 0)
                        wallJumpPower.x *= -1;

                    rb.AddForce(wallJumpPower);
                    GetComponent<HorizontalMovement>().dir = HorizontalMovement.Directions.RIGHT;
                }
                
            }
            else
            {
                rb.AddForce(Vector2.up * jumpForce);
            }

            jumpsLeft--;

            if (jumpsLeft == 0)
            {
                canJump = false;
            }

        } else if (!canJump && groundDetector.grounded)
        {
            jumpsLeft = jumps;
            rb.AddForce(Vector2.zero);
        }

    
    }
}
