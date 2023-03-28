using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialMovement : MonoBehaviour
{
    [Header("Aerial Movement Settings")]
    public float accelerateSpeed;

    [Header("Movement Speed")]
    public float currentSpeed;

    private void FixedUpdate()
    {
        if (PlayerController.instance.isJumping)
        {
            float horizontal = Input.GetAxis("Horizontal");
            PlayerController.instance.isMoving = IsMoving(horizontal);

            currentSpeed = horizontal * accelerateSpeed;

            CheckDirection(currentSpeed);
            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentSpeed, 0));
        }
    }


    bool IsMoving(float horizontal)
    {
        return horizontal != 0;
    }

    void CheckDirection(float speed)
    {
        if (speed > 0)
        {
            PlayerController.instance.sprite.flipX = false;
            PlayerController.instance.dir = PlayerController.Directions.RIGHT;
        }
        else if (speed < 0)
        {
            PlayerController.instance.sprite.flipX = true;
            PlayerController.instance.dir = PlayerController.Directions.LEFT;
        }
    }
}
