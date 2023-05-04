using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DoubleJumpDHM : MonoBehaviour
{

    Rigidbody2D rb;
    WalljumpDHM wj;

    public bool canJump = true;
    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;
    public float fallingGravityScale = 3.0f;

    Animator anim;
    int jumpsLeft = 1;

    [Header("Audio")]
    [SerializeField] private AudioSource dobleJumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        wj = GetComponent<WalljumpDHM>();
    }

    // Update is called once per frame
    void Update()
    {

        if (wj.IsInWall()) { return; }

        if (canJump = anim.GetBool("isJumping"))
        {
            if (jumpsLeft == 1)
            {
                if (Input.GetButtonDown("Jump") && canJump)
                {
                    dobleJumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    canJump = false;
                    rb.gravityScale = jumpGravityScale;
                    jumpsLeft--;
                }
            }    
        }
        else
        {
            jumpsLeft = 1;
        }
    }
}
