using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementDHM : MonoBehaviour
{
    public float speed = 5;
    public float currentSpeed;

    public enum Directions { NONE, RIGHT, LEFT };
    public Directions dir = Directions.NONE;

    SpriteRenderer sr;
    Animator anim;
    GroundDetectorDHM ground;
    JumpDHM jumping;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ground = GetComponent<GroundDetectorDHM>();
        dir = Directions.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Movimiento del personaje + no entra dentro de paredes
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.fixedDeltaTime, 0, 0); // El deltTime de las físicas

        //cambio de escala da problemas con la plataforma así que lo cambiaremos solo visualmente
        if (horizontal > 0)
        {
            sr.flipX = false;
            dir = Directions.RIGHT;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            sr.flipX = true;
            dir = Directions.LEFT;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        anim.SetBool("Moving", horizontal != 0);
        anim.SetBool("Grounded", ground.grounded);
        //anim.SetBool("Jumping", jumping.jump);

    }
}
