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
        if (!CheckForceDirection())
        {
            canDash = true;
            PlayerController.instance.isDashing = false;
            yield return null;
        }
        PlayerController.instance.isDashing = true;

        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(dashForce, 0);

        yield return new WaitForSeconds(dashTime);

        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = baseGravity * 5;
        PlayerController.instance.isDashing = false;

        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
