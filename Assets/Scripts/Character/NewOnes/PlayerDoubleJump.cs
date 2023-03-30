using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    [Header("Jump Forces")]
    public float jumpForce;
    public float jumpSpeed;
    public float fallSpeed;

    [Header("Jump Direction")]
    public float angleJump;
    public Vector2 jumpDirection;

    bool doubleJump;
    float timer = 1;
    float time = 0;

    private void Update()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (Input.GetButtonDown("Jump") && PlayerController.instance.isJumping && PlayerController.instance.canJump && !PlayerController.instance.isInWall)
        {
            SetJumpDirection();
            doubleJump = true;
            time = timer;
        }

        time -= Time.deltaTime;

        if (time <= 0)
        {
            doubleJump = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doubleJump)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            SetJumpDirection();

            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(jumpDirection * jumpForce);
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x * jumpSpeed, jumpSpeed);

            PlayerController.instance.canJump = false;
            doubleJump = false;
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
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, fallSpeed);
        }
    }
}
