using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walljump : MonoBehaviour
{
    [Header("Walljump Settings")]
    public float distance;
    public LayerMask wallLayer;

    [Header("Walljump Settings")]
    public bool isInWall;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Jump jumpScript;
    GroundDetector2 ground;

    // Start is called before the first frame update
    void Start()
    {
        isInWall = false;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        jumpScript = GetComponent<Jump>();
        ground = GetComponent<GroundDetector2>();
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

            if (dir > 0 ) {
                sr.flipX = true;
            }
            if (dir < 0)
            {
                sr.flipX = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jumpScript.jumpsLeft = 2;
            }
        }
    }
}
