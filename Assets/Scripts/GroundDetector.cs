using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    public bool grounded = false;

    public float groundDistance = 1.5f;
    public LayerMask groundMask;

    public List<Vector3> rays;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int count = 0;

        for (int i = 0; i < rays.Count; i++)
        {

            Debug.DrawRay(transform.position + rays[i], transform.up * -1 * groundDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + rays[i], transform.up * -1, groundDistance, groundMask);

            if (hit.collider != null)
            {
                count++;
                Debug.DrawRay(transform.position + rays[i], transform.up * -1 * hit.distance, Color.green);
            }

            if (count > 0)
            {
                grounded = true;
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = 2.2f;
                grounded = false;
            }
        }
    }
}
