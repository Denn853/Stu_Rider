using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public bool canDash = true;
    public float force = 16f;
    public float dashingTime = 0.2f;
    public float coolDownTime = 1.3f;
    
    HorizontalMovement target;
    GroundDetector2 gd;
    Rigidbody2D rb;
    TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<HorizontalMovement>();
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetector2>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Dash") && canDash && !gd.grounded) {

            StartCoroutine(Dash_Corutine());

        }
    }

    IEnumerator Dash_Corutine()
    {
        canDash = false;

        if (target.dir == HorizontalMovement.Directions.LEFT)
        {
            rb.velocity = new Vector2(Vector2.left.x * force, 0f);
        }
        else
        {
            rb.velocity = new Vector2(Vector2.right.x * force, 0f);
        }

        CoolDownController.instance.CoolDown(0);
        yield return new WaitForSeconds(dashingTime);
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(coolDownTime);  
        canDash = true;
        CoolDownController.instance.ComeBack(0);
    }
}
