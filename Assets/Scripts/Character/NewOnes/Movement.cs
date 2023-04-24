using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed;
    public float accelerateSpeed;
    public float decelerateSpeed;

    [Header("Movement Speed")]
    public float currentSpeed;

    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.isMoving = false;
        PlayerController.instance.dir = PlayerController.Directions.NONE;
        gravity = PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale;
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

            AddForce();
            LimitSpeedBody(horizontal);
        }
    }


    bool IsMoving(float horizontal)
    {
        return horizontal != 0;
    }

    void AddForce()
    {

        if (PlayerController.instance.isOnSlope)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = 0;
            float vel = PlayerController.instance.GetComponent<Rigidbody2D>().velocity.magnitude;
            //PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * PlayerController.instance.slopeAngle) * vel, Mathf.Sin(Mathf.Deg2Rad * PlayerController.instance.slopeAngle) * vel );
            PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * PlayerController.instance.slopeAngle) * vel, Mathf.Sin(Mathf.Deg2Rad * PlayerController.instance.slopeAngle) * currentSpeed + 9.81f));
            return;
        }

        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = gravity;
        PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentSpeed, 0));
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
            Vector3 vel = Vector3.Lerp(PlayerController.instance.GetComponent<Rigidbody2D>().velocity, new Vector3(0.0f, PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y, 0), decelerateSpeed);
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = vel;
        }

        if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x > maxSpeed && !PlayerController.instance.isOnSlope)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * PlayerController.instance.slopeAngle) * maxSpeed, 0);
        } 
        else if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed && !PlayerController.instance.isOnSlope)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * PlayerController.instance.slopeAngle) * -maxSpeed, 0);
        }
    }
}
