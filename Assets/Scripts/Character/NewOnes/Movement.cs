using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum Directions { NONE, RIGHT, LEFT };
    
    [Header("Movement Settings")]
    public float speed;

    [Header("Movement Direction")]
    public Directions dir = Directions.NONE;

    [Header("Movement Speed")]
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.isMoving = false;
        dir = Directions.NONE;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        PlayerController.instance.isMoving = IsMoving(horizontal);
        
        currentSpeed = horizontal * speed;

        CheckDirection(currentSpeed);

        PlayerController.instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentSpeed, 0));
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
            dir = Directions.RIGHT;
        } 
        else
        {
            PlayerController.instance.sprite.flipX = true;
            dir = Directions.LEFT;
        }
    }
}
