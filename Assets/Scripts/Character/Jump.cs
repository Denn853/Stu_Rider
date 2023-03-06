using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 10;
    public float jumpTimer;
    public float jumps;

    [Header("Jump status")]
    public bool canJump; 
    public float jumpsLeft;

    Rigidbody2D rb;
    GroundDetector groundDetector;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
        timer = jumpTimer;
        jumpsLeft = jumps;
    }

    // Update is called once per frame
    void Update()
    {

        canJump = jumpsLeft > 0;

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpsLeft--;

            if (jumpsLeft == 0)
            {
                canJump = false;
                timer = 1.25f;
            }

        } else if (!canJump && timer <= 0 && groundDetector.grounded)
        {
            jumpsLeft = jumps;
        }

        timer -= Time.deltaTime;
    
    }
}
