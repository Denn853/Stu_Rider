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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (Input.GetButtonDown("Jump") && PlayerController.instance.isGrounded)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            SetJumpDirection();

            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(jumpDirection * jumpForce);
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x * jumpSpeed, jumpSpeed);

            GameObject temp = Instantiate(dustParticles, transform.position, transform.rotation);
            Destroy(temp, 0.5f);
        }

        if (PlayerController.instance.isJumping)
            CheckRigidBodyVelocity();
    }

    void SetJumpDirection()
    {
        switch (PlayerController.instance.dir)
        {
            case PlayerController.Directions.NONE:

                jumpDirection = Vector2.up;
                break;

            case PlayerController.Directions.RIGHT:

                jumpDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleJump), Mathf.Sin(Mathf.Deg2Rad * angleJump));
                break;

            case PlayerController.Directions.LEFT:

                jumpDirection = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angleJump), Mathf.Sin(Mathf.Deg2Rad * angleJump));
                break;
        }
    }

    void CheckRigidBodyVelocity()
    {
        if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            if (PlayerController.instance.isInWall && !PlayerController.instance.isWallJump)
            { 
                PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, fallInWallSpeed);
                return;
            }   
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, fallSpeed);
        }
    }
}
