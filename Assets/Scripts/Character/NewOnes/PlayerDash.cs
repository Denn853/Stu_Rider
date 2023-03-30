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
            PlayerController.instance.isDashing = true;
            canDash = false;
        }
    }

    private void FixedUpdate()
    {
        if (!canDash)
            StartCoroutine(Dash());
    }

    bool CheckForceDirection()
    {
        if (PlayerController.instance.dir == PlayerController.Directions.LEFT && dashForce > 0)
        {
            dashForce *= -1;
            return true;
        }
        else if (PlayerController.instance.dir == PlayerController.Directions.RIGHT && dashForce < 0)
        {
            dashForce *= -1;
            return true;
        }

        return false;
    }

    IEnumerator Dash()
    {
        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = 0f;

        if (!CheckForceDirection())
        {
            canDash = true;
            PlayerController.instance.isDashing = false;
            yield return null;
        }

        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(dashForce, 0);

        yield return new WaitForSeconds(dashTime);

        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(dashForce / 2, 0);
        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = baseGravity;
        PlayerController.instance.isDashing = false;

        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
