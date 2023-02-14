using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    public bool hook = false;
    public GameObject hookPrefab;
    public float speedHook;
    public float hookDistance = 5;
    public LayerMask hookMask;
    public List<Vector3> rays;

    float offset;
    float angle;
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

        for (int i = 0; i < rays.Count; i++)
        {
            angle = i * offset;

            dir = Quaternion.Euler(0, 0, angle) * transform.right;
            Debug.DrawRay(transform.position, dir * hookDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, hookDistance, hookMask);
        
            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position, dir * hit.distance, Color.cyan);
                positionToMove = hit.transform.position;
                hook = true;
                break;
            }

            hook = false;
        
        }

        if (Input.GetButtonDown("Hook") && hook)
        {
            transform.position = Vector3.Lerp(transform.position, positionToMove, speedHook * Time.deltaTime);

            GameObject temp = Instantiate(hookPrefab, transform.position, transform.rotation);
            temp.transform.eulerAngles += new Vector3(0, 0, angle - 90);
            Destroy(temp, 0.4f);
        }
    }
}
