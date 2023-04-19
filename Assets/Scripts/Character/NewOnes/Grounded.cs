using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Grounded : MonoBehaviour
{
    [Header("RayCast Settings")]
    public float groundDistance = 1.5f;
    public List<Vector3> rays;
    public LayerMask groundMask;

    [Header("Slopes Settings")]
    [SerializeField] private GameObject GroundContact;

    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private Vector2 slopeNormalPerp;

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        SlopeCheck();
    }

    private void GroundCheck()
    {
        int count = 0;

        for (int i = 0; i < rays.Count; i++)
        {
            Debug.DrawRay(transform.position + rays[i], transform.up * -1 * groundDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + rays[i], transform.up * -1, groundDistance, groundMask);

            if (hit.collider != null)
            {
                count++;

                Vector3 pos = new Vector3(0, hit.distance, 0);
                Debug.DrawRay(transform.position + rays[i] - pos, transform.up * (hit.distance - groundDistance), Color.green);
            }

            if (count > 0)
            {
                PlayerController.instance.isGrounded = true;
                PlayerController.instance.canJump = true;
                PlayerController.instance.isJumping = false;
                PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerController.instance.GetComponent<Rigidbody2D>().velocity.x, 0.0f);
                PlayerController.instance.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else
            {
                PlayerController.instance.isGrounded = false;
                PlayerController.instance.isJumping = true;
            }
        }
    }

    private void SlopeCheck()
    {
        SlopeCheckVertical();
    }

    private void SlopeCheckHorizontal()
    {

    }

    private void SlopeCheckVertical()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rays[1], Vector2.down, groundDistance, groundMask);

        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != 0)
                PlayerController.instance.isOnSlope = true;
            else
                PlayerController.instance.isOnSlope = false;

            slopeDownAngleOld = slopeDownAngle;
            PlayerController.instance.slopeAngle = slopeDownAngle;

            Debug.DrawRay(hit.point, hit.normal, Color.cyan);
            Debug.DrawRay(hit.point, slopeNormalPerp, Color.magenta);
        }
    }
}
