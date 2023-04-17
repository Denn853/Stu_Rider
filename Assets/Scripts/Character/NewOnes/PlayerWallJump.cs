using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour
{
    [Header("WallJump Settings")]
    public float jumpForce;

    [Header("WallJump Direction")]
    public float angleJump;
    public Vector2 jumpDirection;

    [Header("WallJump Time reset")] 
    public float timeReset;
    float time;

    bool wallJump;

    private void Update()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (Input.GetButtonDown("Jump") && PlayerController.instance.isJumping && PlayerController.instance.isInWall)
        {
            wallJump = true;
            time = timeReset;
        }

        if (time <= 0)
        {
            PlayerController.instance.isWallJump = false;
        }

        time -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (wallJump)
        {
            ExecuteWallJump();
            wallJump = false;
        }
    }

    void ExecuteWallJump()
    {
        CheckDirection();

        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(jumpDirection * (jumpForce + 9.81f));
        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = 2.5f;

        PlayerController.instance.isWallJump = true;
    }

    void CheckDirection()
    {
        if (PlayerController.instance.walldir == PlayerController.Directions.RIGHT)
        {
            PlayerController.instance.sprite.flipX = true;
            jumpDirection = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angleJump), Mathf.Sin(Mathf.Deg2Rad * angleJump));
        }
        else
        {
            PlayerController.instance.sprite.flipX = false;
            jumpDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angleJump), Mathf.Sin(Mathf.Deg2Rad * angleJump));
        }
    }
}
