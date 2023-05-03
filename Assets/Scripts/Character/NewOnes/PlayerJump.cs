using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Forces")]
    public float jumpForce;

    [Header("Jump gravity")]
    public float jumpGravity;

    [Header("Falling Gravities")]
    public float fallingGravity;
    public float fallingWallGravity;

    [Header("Jump Direction")]
    public Vector2 jumpDirection;
    public float angleJump;

    [Header("Particles")]
    public GameObject dustParticles;

    bool jump = false;
    float timer = 1;
    float time = 0;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Update()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (Input.GetButtonDown("Jump") && PlayerController.instance.isGrounded)
        {
            jumpSoundEffect.Play();

            jump = true;
            time = timer;
        }

        time -= Time.deltaTime;

        if (time <= 0)
        {
            jump = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(PlayerController.instance.GetComponent<Rigidbody2D>().velocity);

        if (jump)
        {
            AddForce();

            GameObject temp = Instantiate(dustParticles, transform.position, transform.rotation);
            Destroy(temp, 0.5f);
            
            jump = false;
        }

        if (PlayerController.instance.isJumping && PlayerController.instance.canJump && !PlayerController.instance.isDashing)
            CheckGravity();
    }

    void CheckGravity()
    {
        if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y <= 0 && !PlayerController.instance.isGrounded)
        {
            if (PlayerController.instance.isInWall && !PlayerController.instance.isWallJump)
            {
                PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = fallingWallGravity;
            }
            else
            {
                PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = fallingGravity;
            }
        }
    }

    void AddForce()
    {
        PlayerController.instance.isJumping = true;

        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        
        PlayerController.instance.isGrounded = false;
    }
}
