using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementDHM : MonoBehaviour
{
    public float speed = 5;
    public float currentSpeed;

    public enum Directions { NONE, RIGHT, LEFT };
    public Directions dir = Directions.NONE;

    CapsuleCollider2D collider;
    SpriteRenderer sr;
    Animator anim;
    GroundDetectorDHM ground;
    JumpDHM jumping;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ground = GetComponent<GroundDetectorDHM>();
        collider = GetComponent<CapsuleCollider2D>();
        dir = Directions.NONE;
    }

    private void FixedUpdate()
    {
        //Movimiento del personaje + no entra dentro de paredes
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.fixedDeltaTime, 0, 0); // El deltTime de las f�sicas

        //cambio de escala da problemas con la plataforma as� que lo cambiaremos solo visualmente
        if (horizontal > 0)
        {
            sr.flipX = false;
            dir = Directions.RIGHT;
            collider.offset = new Vector2(-0.225f, -0.25f);
            //transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            sr.flipX = true;
            dir = Directions.LEFT;
            collider.offset = new Vector2(0.225f, -0.25f);
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        anim.SetBool("isWalking", horizontal != 0);
        anim.SetBool("Grounded", ground.grounded);
        //anim.SetBool("Jumping", jumping.jump);

    }

    public void Respawn()
    {
        transform.position = lastPosition;
    }

    public void CheckPoint(Vector3 position)
    {
        lastPosition = position;
    }
}
