using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDHM : MonoBehaviour
{
    Rigidbody2D rb;
    GroundDetectorDHM gd;
    WalljumpDHM wj;
    Animator anim;
    int jumpsLeft;

    [Header("Jump Settings")]
    public bool canJump = true;
    public float jumpForce = 10;
    public float jumpGravityScale = 2.2f;
    public float fallingGravityScale = 3.0f;
    public int jumps;

    [Header("Jump Particles")]
    public GameObject jumpParticles;
    public Transform jumpParticlesTransform;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GetIsPaused()) { return; }

        canJump = gd.grounded;

        if (canJump)
        {
            jumpsLeft = jumps;

            if (Input.GetButtonDown("Jump") && canJump)
            {
                Jump();
                CheckGravity();
            } 
        }
        else if (jumpsLeft > 0 && Input.GetButtonDown("Jump"))
        {
            jumpsLeft--;
            Jump();
            CheckGravity();
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