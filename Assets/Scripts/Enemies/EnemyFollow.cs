using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Enemy Follow Settings")]
    public GameObject target;
    public float speed;
    public float distance;
    public GameObject offsetObject;
    public Transform pointBack;

    [Header("Follow Status")]
    public bool isFollowing;

    EnemyHorizontalMovement ehm;
    EnemyFieldOfView efov;
    EnemyGroundDetector egd;

    // Start is called before the first frame update
    void Start()
    {
        ehm = GetComponent<EnemyHorizontalMovement>();
        efov = GetComponent<EnemyFieldOfView>();
        egd = GetComponent<EnemyGroundDetector>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (efov.canSeePlayer && egd.grounded)
        {
            FollowPlayer();
        }
        else
        {
            ehm.enabled = true;
        }
    }

    void FollowPlayer()
    {
        ehm.enabled = false;

        Vector3 dir = target.transform.position - transform.position;
        distance = dir.magnitude;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }
}
