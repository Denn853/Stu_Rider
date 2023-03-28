using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    public float speed = 5;
    public float currentSpeed;
    public SpriteRenderer sr;

    public Animator anim;
    public GroundDetector2 ground;



    public enum Directions { NONE, RIGHT, LEFT };
    public Directions dir = Directions.NONE;

    private void Start()
    {
        dir = Directions.NONE;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        currentSpeed = horizontal * speed;

        if (horizontal > 0)
        {
            dir = Directions.RIGHT;
            sr.flipX = false;
        } 
        else if (horizontal < 0)
        {
            dir = Directions.LEFT;
            sr.flipX = true;
        }

        transform.position += new Vector3(horizontal * speed * Time.fixedDeltaTime, 0, 0);
        anim.SetBool("isWalking", horizontal != 0);
    }
}
