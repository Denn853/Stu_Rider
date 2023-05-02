using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    [Header("Jump Forces")]
    public float jumpForce;

    bool doubleJump;
    float timer = 1;
    float time = 0;

    private void Update()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (Input.GetButtonDown("Jump") && PlayerController.instance.isJumping && PlayerController.instance.canJump && !PlayerController.instance.isInWall)
        {
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

            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, jumpForce);

            PlayerController.instance.canJump = false;
            doubleJump = false;
        }
    }
}
