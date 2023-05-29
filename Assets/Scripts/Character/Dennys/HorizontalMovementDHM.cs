using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementDHM : MonoBehaviour
{
    public float speed = 5;
    public float currentSpeed;

    public enum Directions { NONE, RIGHT, LEFT };
    public Directions dir = Directions.NONE;
    public GameObject follower;

    public Timer timer;

    CapsuleCollider2D collider;
    SpriteRenderer sr;
    Animator anim;
    GroundDetectorDHM ground;
    JumpDHM jumping;
    DashDHM dash;

    Vector3 lastPosition;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ground = GetComponent<GroundDetectorDHM>();
        collider = GetComponent<CapsuleCollider2D>();
        dash = GetComponent<DashDHM>();
        dir = Directions.NONE;

        lastPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown("CheckpointCheat"))
            Respawn();
    }

    private void FixedUpdate()
    {

        
        if (!dash.cooldown && !dash.canDash) { 
            Debug.Log("Cooldown: " + dash.cooldown + " - Dash: " + dash.canDash);
            return;
        }

        //Movimiento del personaje + no entra dentro de paredes
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.fixedDeltaTime, 0, 0); // El deltTime de las físicas

        //cambio de escala da problemas con la plataforma así que lo cambiaremos solo visualmente
        if (horizontal > 0)
        {
            sr.flipX = false;
            dir = Directions.RIGHT;
            collider.offset = Vector2.Lerp(collider.offset, new Vector2(-0.225f, -0.25f), 0.6f);
            //transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            sr.flipX = true;
            dir = Directions.LEFT;
            collider.offset = Vector2.Lerp(collider.offset, new Vector2(0.225f, -0.25f), 0.6f);
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        anim.SetBool("isWalking", horizontal != 0);
        anim.SetBool("Grounded", ground.grounded);
        //anim.SetBool("Jumping", jumping.jump);

    }

    public void Respawn()
    {
        transform.position = lastPosition;
        timer.ResetTime(time);
    }

    public void CheckPoint(Vector3 position)
    {
        lastPosition = position;
    }

    public void CheckPointTime(float time)
    {
        this.time = time;
    }
}
