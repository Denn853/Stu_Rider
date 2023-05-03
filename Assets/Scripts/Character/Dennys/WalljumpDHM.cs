using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalljumpDHM : MonoBehaviour
{

    [Header("Wall Detection")]
    public float distance;
    public LayerMask wallLayer;
    [SerializeField] private bool isInWallRight;
    [SerializeField] private bool isInWallLeft;

    [Header("Jump Settings")]
    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;

    Rigidbody2D rb;
    Animator anim;

    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectWall();
    }

    void DetectWall()
    {
        Vector2 origin = (Vector2)transform.position;

        RaycastHit2D right = Physics2D.Raycast(origin, Vector2.right, distance, wallLayer);
        Debug.DrawRay(origin, Vector2.right * distance, Color.yellow);
        RaycastHit2D left = Physics2D.Raycast(origin, Vector2.right, -distance, wallLayer);
        Debug.DrawRay(origin, Vector2.right * -distance, Color.yellow);

        if (right.collider != null)
        {
            Debug.DrawRay(origin, Vector2.right * right.distance, Color.green);
            isInWallRight = true;
            isInWallLeft = false;
            anim.SetBool("isWalljumping", true);
            canJump = true;
        }
        else if (left.collider != null)
        {
            Debug.DrawRay(origin, Vector2.right * -left.distance, Color.green);
            isInWallRight = false;
            isInWallLeft = true;
            anim.SetBool("isWalljumping", true);
            canJump = true;
        }
        else
        {
            isInWallRight = false;
            isInWallLeft = false;
            anim.SetBool("isWalljumping", false);
            canJump = false;

            return;
        }

        float gravity = rb.gravityScale;

        rb.gravityScale = 1;
        rb.velocity = new Vector2(rb.velocity.x, 0);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            if (isInWallRight)
                rb.AddForce(new Vector2(-0.75f, 1) * jumpForce, ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(0.75f, 1) * jumpForce, ForceMode2D.Impulse);
        }

        rb.gravityScale = gravity;
    }

    public bool IsInWall()
    {
        return canJump;
    }
}
