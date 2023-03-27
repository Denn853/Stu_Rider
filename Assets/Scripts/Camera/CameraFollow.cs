using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    public float speed;
    public float offsetX;
    public float offsetY;
    
    public Vector3 offset;
    Rigidbody2D rb;
    HorizontalMovement targetMovement;
    GroundDetector gd;

    private void Start()
    {
        targetMovement = target.GetComponent<HorizontalMovement>();
        rb = targetMovement.GetComponent<Rigidbody2D>();
        gd = targetMovement.GetComponent<GroundDetector>();
    }

    void LateUpdate()
    {
        offset = new Vector3(0, offsetY, -10);
        speed = 1.5f;

        if (targetMovement != null)
        {
            if (targetMovement.dir == HorizontalMovement.Directions.RIGHT || targetMovement.dir == HorizontalMovement.Directions.NONE)
            {
                offsetX = 10;
                offset += Vector3.right * offsetX;
            }
            else if (targetMovement.dir == HorizontalMovement.Directions.LEFT && targetMovement.currentSpeed != 0)
            {
                offsetX = 1;
                offset += Vector3.left * offsetX;
            }

            //if (targetMovement.currentSpeed != 0)
            //{
            //    offset.x += offsetX;
            //}

            if (rb.velocity.y < -20 && !gd.grounded)
            {
                offsetY = -5;
                offset.y = offsetY;
            }
            else if (rb.velocity.y > 0 || gd.grounded)
            {
                offsetY = 1;
                offset.y = offsetY;
            }

            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);
        }
   
    }
}
