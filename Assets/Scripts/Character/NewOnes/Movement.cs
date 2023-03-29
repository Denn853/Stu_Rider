using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed;
    public float accelerateSpeed;
    public float decelerateSpeed;

    [Header("Movement Speed")]
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.isMoving = false;
        PlayerController.instance.dir = PlayerController.Directions.NONE;
    }

    private void FixedUpdate()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (PlayerController.instance.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            PlayerController.instance.isMoving = IsMoving(horizontal);

            currentSpeed = horizontal * accelerateSpeed;

            CheckDirection(currentSpeed);

            if(PlayerController.instance.dir == PlayerController.Directions.NONE) { return; };

            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentSpeed, 0));
            LimitSpeedBody(horizontal);
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
        else
        {
            PlayerController.instance.dir = PlayerController.Directions.NONE;
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    void LimitSpeedBody(float horizontal)
    {
        if (horizontal == 0)
        {
            Vector3 vel = Vector3.Lerp(PlayerController.instance.GetComponent<Rigidbody2D>().velocity, new Vector3(0.1f, PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y, 0), decelerateSpeed);
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = vel;
        }

        if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x > maxSpeed)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, 0);
        } 
        else if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, 0);
        }
    }
}
