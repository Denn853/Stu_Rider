using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;
    public float fallingGravityScale = 3.0f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.gravityScale = jumpGravityScale;
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }
}
