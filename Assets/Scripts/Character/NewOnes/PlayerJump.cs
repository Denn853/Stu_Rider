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

    private void Update()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (Input.GetButtonDown("Jump") && PlayerController.instance.isGrounded)
        {
            SetJumpDirection();
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
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            AddForce();

            GameObject temp = Instantiate(dustParticles, transform.position, transform.rotation);
            Destroy(temp, 0.5f);
            
            jump = false;
        }

        if (PlayerController.instance.isJumping && PlayerController.instance.canJump && !PlayerController.instance.isDashing)
            CheckGravity();
    }

    void SetJumpDirection()
    {
        switch (PlayerController.instance.dir)
        {
            case PlayerController.Directions.NONE:

                jumpDirection = Vector2.up;
                break;

            case PlayerController.Directions.RIGHT:

                jumpDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleJump), 1);
                break;

            case PlayerController.Directions.LEFT:

                jumpDirection = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angleJump), 1);
                break;
        }
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

        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = jumpGravity;
        //PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(jumpDirection * (jumpForce));
        PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (jumpForce));
        
        PlayerController.instance.isGrounded = false;
    }
}
