using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFollowerDirection : MonoBehaviour
{

    [Header("Follower offset")]
    public Vector3 offset;
    public float speed;

    private void LateUpdate()
    {
        if (PlayerController.instance.isDashing) { return; }

        if (PlayerController.instance.dir == PlayerController.Directions.RIGHT)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.instance.transform.position + offset, speed * Time.deltaTime);
        }
        else if (PlayerController.instance.dir == PlayerController.Directions.LEFT)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.instance.transform.position - offset, speed * Time.deltaTime);
        }
    }
}
