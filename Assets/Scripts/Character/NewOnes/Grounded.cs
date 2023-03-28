using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    [Header("RayCast Settings")]
    public float groundDistance = 1.5f;
    public List<Vector3> rays;
    public LayerMask groundMask;

    // Update is called once per frame
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
                PlayerController.instance.isGrounded = true;
            }
            else
            {
                PlayerController.instance.isGrounded = false;
            }
        }
    }
}
