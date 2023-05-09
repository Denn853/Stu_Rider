using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetectorDHM : MonoBehaviour
{

    [Header("Ground Detector Settings")]
    public bool grounded;
    [SerializeField] private float groundDistance = 1.5f;
    public List<Vector3> rays;
    public LayerMask groundMask;

    Rigidbody2D rb;
    SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (rb.velocity.y > 0) { return; }

        int count = 0;

        if (sr.flipX)
        {
            rays[0] = new Vector3(0.5f, -0.91f, 0);
            rays[1] = new Vector3(0.13f, -0.91f, 0);
            rays[2] = new Vector3(-0.19f, -0.91f, 0);
        }
        else
        {
            rays[0] = new Vector3(0.19f, -0.91f, 0);
            rays[1] = new Vector3(-0.15f, -0.91f, 0);
            rays[2] = new Vector3(-0.5f, -0.91f, 0);
        }

        //Accedemos a la lista Rays iterandola con un for
        for (int i = 0; i < rays.Count; i++)
        {
            //Nos dibuja un rayo que va siempre a los pies del personaje
            Debug.DrawRay(transform.position + rays[i], transform.up * -1 * groundDistance, Color.magenta);

            //Accedes al motor de fisicas y le indicas que usamos el raycast
            RaycastHit2D hit = Physics2D.Raycast(transform.position + rays[i], transform.up * -1, groundDistance, groundMask);

            if (hit.collider != null)
            {
                count++;
                Debug.DrawRay(transform.position + rays[i], transform.up * -1 * hit.distance, Color.green);
                if (hit.transform.tag == "Platform")
                {
                    transform.parent = hit.transform;
                }
                else
                {
                    transform.parent = null;
                }
            }
        }
        if (count > 0)
        {
            grounded = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            grounded = false;
            transform.parent = null;
        }
    }
}
