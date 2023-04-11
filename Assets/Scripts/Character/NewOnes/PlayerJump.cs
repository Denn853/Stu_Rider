using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Forces")]
    public float jumpForce;
    public float jumpSpeed;
    public float fallSpeed;

    [Header("WallJump Fall Speed")]
    public float fallInWallSpeed;

    [Header("Jump Direction")]
    public float angleJump;
    public Vector2 jumpDirection;

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
            CheckRigidBodyVelocity();
    }

    void SetJumpDirection()
    {
        switch (PlayerController.instance.dir)
        {
            case PlayerController.Directions.NONE:

                jumpDirection = Vector2.up * 1.5f;
                break;

            case PlayerController.Directions.RIGHT:

                jumpDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleJump), Mathf.Sin(Mathf.Deg2Rad * angleJump)) * 1.5f;
                break;

            case PlayerController.Directions.LEFT:

                jumpDirection = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angleJump), Mathf.Sin(Mathf.Deg2Rad * angleJump)) * 1.5f;
                break;
        }
    }

    void CheckRigidBodyVelocity()
    {
        if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            if (PlayerController.instance.isInWall && !PlayerController.instance.isWallJump)
            { 
                PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, 0), new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, fallSpeed), 0.0002f);
            } 
            else
            {
                PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, 0), new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, fallSpeed * 2), 0.35f);
            } 
        }
    }

    void AddForce()
    {
        if (PlayerController.instance.dir == PlayerController.Directions.RIGHT || PlayerController.instance.dir == PlayerController.Directions.LEFT)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(jumpDirection * (jumpForce + 9.81f));
        }
        else
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(jumpDirection * jumpForce);
        }
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x * jumpSpeed, jumpSpeed * Time.fixedDeltaTime);
    }
}
