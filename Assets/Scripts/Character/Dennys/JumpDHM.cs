using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDHM : MonoBehaviour
{
    Rigidbody2D rb;
    GroundDetectorDHM gd;

    public bool canJump = true;
    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;
    public float fallingGravityScale = 3.0f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetectorDHM>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!PauseMenu.instance.isPaused)
       // {

            if (canJump = gd.grounded)
            {
                if (Input.GetButtonDown("Jump") && canJump)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    canJump = false;
                    rb.gravityScale = jumpGravityScale;
                }

                if (rb.velocity.y >= 0)
                {
                    rb.gravityScale = jumpGravityScale;
                }

                if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallingGravityScale;
                }
            }

            anim.SetBool("isJumping", !gd.grounded);
    }
}