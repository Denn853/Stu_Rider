using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDHM : MonoBehaviour
{
    Rigidbody2D rb;
    GroundDetectorDHM gd;
    WalljumpDHM wj;
    Animator anim;

    [Header("Jump Settings")]
    public bool canJump = true;
    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;
    public float fallingGravityScale = 3.0f;
    public int jumps;
    [SerializeField] private int jumpsLeft;
    private float coyoteTime = 0.8f;
    [SerializeField] private float coyoteTimeCounter;
    private float jumpBufferTime = 0.5f;
    [SerializeField] private float jumpBufferTimeCounter;

    [Header("Jump Particles")]
    public GameObject jumpParticles;
    public GameObject doubleJumpParticles;
    public Transform jumpParticlesTransform;
    public Transform doubleJumpParticlesTransform;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;

    [Header("Pause Reference")]
    [SerializeField] private PauseMenu pauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetectorDHM>();
        anim = GetComponent<Animator>();
        wj = GetComponent<WalljumpDHM>();
        jumpsLeft = jumps;
        coyoteTimeCounter = coyoteTime;
        jumpBufferTimeCounter = jumpBufferTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GetIsPaused()) { return; }

        canJump = gd.grounded;

        if (gd.grounded)
        {
            coyoteTimeCounter = coyoteTime;
            jumpsLeft = 1;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        
        if (jumpsLeft == 0 && Input.GetButtonDown("Jump") && !gd.grounded)
        {
            jumpBufferTimeCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferTimeCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0.0f && Input.GetButtonDown("Jump"))
        {
            Jump();
            CheckGravity();
            coyoteTimeCounter = 0.0f;
            jumpBufferTimeCounter = 0.0f;
            jumpsLeft = jumps;
        } 
        else if (jumpsLeft > 0 && Input.GetButtonDown("Jump"))
        {
            jumpsLeft--;
            DoubleJump();
            CheckGravity();
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        anim.SetBool("isJumping", !gd.grounded);
    }

    private void Jump()
    {
        canJump = false;
        gd.grounded = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        jumpSoundEffect.Play();
        GameObject temp = Instantiate(jumpParticles, jumpParticlesTransform.position, transform.rotation);
        Destroy(temp, 0.5f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rb.gravityScale = jumpGravityScale;
    }

    private void DoubleJump()
    {
        canJump = false;
        gd.grounded = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        jumpSoundEffect.Play();
        GameObject temp = Instantiate(doubleJumpParticles, doubleJumpParticlesTransform.position, transform.rotation);
        Destroy(temp, 0.5f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rb.gravityScale = jumpGravityScale;
    }

    private void CheckGravity()
    {
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = jumpGravityScale;
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }
}