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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && DetectWall())
        {
            if (isInWallRight)
                rb.AddForce(new Vector2(-0.5f, 0.5f) * jumpForce, ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(0.5f, 0.5f) * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool DetectWall()
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
        }
        else if (left.collider != null)
        {
            Debug.DrawRay(origin, Vector2.right * -left.distance, Color.green);
            isInWallRight = false;
            isInWallLeft = true;
            anim.SetBool("isWalljumping", true);
        }
        else
        {
            isInWallRight = false;
            isInWallLeft = false;
            anim.SetBool("isWalljumping", false);
        }

        return isInWallRight && isInWallLeft;
    }
}
