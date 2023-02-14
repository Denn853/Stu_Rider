using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    public bool hook = false;
    public float speedHook;
    public float hookDistance = 5;
    public LayerMask hookMask;
    public List<Vector3> rays;

    float offset;
    Vector3 dir;
    Vector3 positionToMove;

    // Start is called before the first frame update
    void Start()
    {
        offset = 360 / rays.Count;
    }

    // Update is called once per frame
    void Update()
    {

        int count = 0;

        for (int i = 0; i < rays.Count; i++)
        {
            dir = Quaternion.Euler(0, 0, i * offset) * transform.right;
            Debug.DrawRay(transform.position, dir * hookDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, hookDistance, hookMask);
        
            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position, dir * hit.distance, Color.cyan);
                positionToMove = hit.transform.position;
                count++;
            }

            if (count > 0)
            {
                hook = true;
            }
            else
            {
                hook = false;
            }
        
        }

        if (Input.GetButtonDown("Hook") && hook)
        {
            transform.position = Vector3.Lerp(transform.position, positionToMove, speedHook * Time.deltaTime)
        }
    }
}
