using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    [Header("Wall Detection")]
    public float distance;
    public LayerMask wallLayer;

    private void Start()
    {
        PlayerController.instance.isInWall = false;
    }

    private void Update()
    {
        if (!PlayerController.instance.isWallJump)
            DetectWall();
    }

    void DetectWall()
    {
        Vector2 origin = (Vector2)transform.position;

        RaycastHit2D right = Physics2D.Raycast(origin, Vector2.right, distance, wallLayer);
        Debug.DrawRay(origin, Vector2.right * distance, Color.yellow);
        RaycastHit2D left = Physics2D.Raycast(origin, Vector2.right, -distance, wallLayer);
        Debug.DrawRay(origin, Vector2.right * -distance, Color.yellow);

        if (right.collider != null)
        {
            PlayerController.instance.walldir = PlayerController.Directions.RIGHT;
            Debug.DrawRay(origin, Vector2.right * right.distance, Color.green);
            PlayerController.instance.isInWall = true;
        }
        else if (left.collider != null)
        {
            PlayerController.instance.walldir = PlayerController.Directions.LEFT;
            Debug.DrawRay(origin, Vector2.right * -left.distance, Color.green);
            PlayerController.instance.isInWall = true;
        }
        else
        {
            PlayerController.instance.isInWall = false;
        }
    }
}
