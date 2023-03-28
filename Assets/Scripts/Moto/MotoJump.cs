using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoJump : MonoBehaviour
{

    public float jumpForce = 10f;

    Rigidbody2D rb;
    GroundDetector2 groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && groundDetector.grounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
