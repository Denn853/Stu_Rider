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
    public GameObject dust;

    [Header("Jump status")]
    public bool canJump; 
    public float jumpsLeft;

    Rigidbody2D rb;
    GroundDetector2 groundDetector;
    Walljump walljump;


    // Start is called before the first frame update
    void Start()
    {
        jumpsLeft = jumps;
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector2>();
        walljump = GetComponent<Walljump>();
    }

    // Update is called once per frame
    void Update()
    {

        canJump = jumpsLeft > 0;

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            if (GetComponent<Walljump>().isInWall && !groundDetector.grounded)
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
                if (groundDetector.grounded)
                {
                    jumpsLeft--;
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y - 0.85f, transform.position.z);
                    GameObject temp = Instantiate(dust, pos, transform.rotation);
                    rb.AddForce(Vector2.up * jumpForce);
                    Destroy(temp, 0.3f);
                } else
                {
                    jumpsLeft--;
                    rb.AddForce(Vector2.up * jumpForce);
                }

            }

            if (jumpsLeft == 0)
            {
                canJump = false;
            }

        } else if (groundDetector.grounded)
        {
            jumpsLeft = jumps;
            rb.velocity = Vector2.zero;
        }

    
    }
}
