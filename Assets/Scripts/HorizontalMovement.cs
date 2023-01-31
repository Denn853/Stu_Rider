using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    public float speed = 5;
    public float currentSpeed;

    public enum Directions {NONE, RIGHT, LEFT };
    public Directions dir = Directions.NONE;

    private void Start()
    {
        dir = Directions.NONE;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        currentSpeed = horizontal * speed;

        if (horizontal > 0)
        {
            dir = Directions.RIGHT;
        } 
        else if (horizontal < 0)
        {
            dir = Directions.LEFT;
        }

        transform.position += new Vector3(horizontal * speed * Time.fixedDeltaTime, 0, 0);

    }
}
