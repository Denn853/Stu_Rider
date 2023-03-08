using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;
    public float distance;

    [Header("Movement Status")]
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[nextPoint].position;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = points[nextPoint].position - transform.position;
        distance = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (nextPoint == 0)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }

        if (distance < 0.5f)
        {
            nextPoint++;

            if (nextPoint >= points.Count)
            {
                nextPoint = 0;
            }
        }
    }
}
