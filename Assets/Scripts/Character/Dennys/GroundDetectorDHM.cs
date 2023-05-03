using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetectorDHM : MonoBehaviour
{
    public bool grounded;
    [SerializeField]
    private float groundDistance = 1.5f;
    public List<Vector3> rays;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;

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
        }
        else
        {
            grounded = false;
            transform.parent = null;
        }
    }
}
