using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walljump : MonoBehaviour
{
    [Header("Walljump Settings")]
    public float distance;
    public float jump;
    public LayerMask wallLayer;

    [Header("Walljump Settings")]
    public bool isInWall;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Jump jumpScript;
    public float jumpTimer;

    // Start is called before the first frame update
    void Start()
    {
        isInWall = false;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        jumpScript = GetComponent<Jump>();
        jumpTimer = jump;
    }

    // Update is called once per frame
    void Update()
    {
        WallJump();
    }

    private void WallJump()
    {
        Vector2 origin = (Vector2)transform.position;

        RaycastHit2D right = Physics2D.Raycast(origin, Vector2.right, distance, wallLayer);
        Debug.DrawRay(origin, Vector2.right * distance, Color.yellow);
        RaycastHit2D left = Physics2D.Raycast(origin, Vector2.right, -distance, wallLayer);
        Debug.DrawRay(origin, Vector2.right * -distance, Color.yellow);

        int dir = 0;

        if (right.collider != null)
        {
            dir = 1;
            Debug.DrawRay(origin, Vector2.right * right.distance, Color.green);
        }
        else if (left.collider != null)
        {
            dir = -1;
            Debug.DrawRay(origin, Vector2.right * -left.distance, Color.green);
        }

        if (dir == 0)
        {
            isInWall = false;
        }
        else
        {
            isInWall = true;
            jumpTimer -= Time.deltaTime;

            if (jumpTimer <= 0)
            {
                rb.velocity = Vector2.up * -1;
            }

            if (dir > 0 ) {
                sr.flipX = true;
            }
            if (dir < 0)
            {
                sr.flipX = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(0, jumpScript.jumpForce);
                jumpScript.jumpsLeft = 1;
                jumpTimer = jump;
            }
        }
    }
}
