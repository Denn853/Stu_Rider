using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class DashDHM : MonoBehaviour
{
    public bool canDash = true;
    public float force = 16f;
    public float dashingTime = 0.2f;
    public float coolDownTime = 1.3f;

    [Header("Dash Particles")]
    public GameObject dashParticles;

    HorizontalMovementDHM target;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<HorizontalMovementDHM>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash_Corutine());
        }
    }

    IEnumerator Dash_Corutine()
    {
        canDash = false;
        float gravity = rb.gravityScale;

        rb.gravityScale = 0;

        anim.SetBool("isDashing", true);

        GameObject temp = Instantiate(dashParticles, transform.position, transform.rotation);
        Destroy(temp, dashingTime);

        if (target.dir == HorizontalMovementDHM.Directions.LEFT)
        {
            rb.velocity = new Vector2(Vector2.left.x * force, 0f);
        }
        else
        {
            rb.velocity = new Vector2(Vector2.right.x * force, 0f);
        }

        yield return new WaitForSeconds(dashingTime);
        anim.SetBool("isDashing", false);
        rb.gravityScale = gravity;
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(coolDownTime);
        canDash = true;
    }
}
