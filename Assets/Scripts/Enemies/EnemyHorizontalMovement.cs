using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{

    public enum Directions { NONE, RIGHT, LEFT };

    [Header("Movement Settings")]
    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;
    public float distance;
    public Animator anim;

    [Header("Movement Status")]
    public Directions direction;

    [Header("Attack Position")]
    public GameObject attack;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[nextPoint].position;
        direction = Directions.LEFT;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", true);

        Vector3 dir = points[nextPoint].position - transform.position;
        distance = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (nextPoint == 0)
        {
            direction = Directions.RIGHT;
            attack.transform.position = new Vector3(transform.position.x + 0.42f, transform.position.y, transform.position.z);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            direction = Directions.LEFT;
            attack.transform.position = new Vector3(transform.position.x - 0.42f, transform.position.y, transform.position.z);
            transform.rotation = new Quaternion(0, 180, 0, 0);
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
