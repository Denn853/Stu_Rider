using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash Settings")]
    public float dashForce;
    public float dashTime;
    public float dashCoolDown;

    [Header("Dash Status")]
    [SerializeField] bool canDash;

    float baseGravity;

    private void Start()
    {
        canDash = true;
        baseGravity = PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void CheckForceDirection()
    {
        if (PlayerController.instance.dir == PlayerController.Directions.LEFT && dashForce > 0)
        {
            dashForce *= -1;
            return;
        }

        if (dashForce < 0)
        {
            dashForce *= -1;
            return;
        }
    }

    IEnumerator Dash()
    {
        PlayerController.instance.isDashing = true;
        canDash = false;
        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = 0f;
        CheckForceDirection();
        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(dashForce, 0);

        yield return new WaitForSeconds(dashTime);

        PlayerController.instance.isDashing = false;
        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = baseGravity;

        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
