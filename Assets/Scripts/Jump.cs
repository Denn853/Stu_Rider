using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;
    public float fallingGravityScale = 3.0f;
    public bool canJump;

    Rigidbody2D rb;

    GroundDetector groundDetector;
    SpawnPunch punch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
        punch = GetComponent<SpawnPunch>();
    }

    // Update is called once per frame
    void Update()
    {

        canJump = !punch.canPuch || groundDetector.grounded;

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        if (Input.GetButtonDown("Jump") && canJump)
        { 
            rb.AddForce(Vector2.up * (jumpForce + rb.gravityScale * 2), ForceMode2D.Impulse);
            rb.gravityScale = jumpGravityScale;
        }

    }
}
