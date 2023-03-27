using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Enemy Follow Settings")]
    public GameObject target;
    public float speed;
    public float distance;
    public Transform pointBack;
    public float distanceToAtatck;

    [Header("Follow Status")]
    public bool isFollowing;
    public bool canAttack = false;

    EnemyHorizontalMovement ehm;
    EnemyFieldOfView efov;
    EnemyGroundDetector egd;

    // Start is called before the first frame update
    void Start()
    {
        ehm = GetComponent<EnemyHorizontalMovement>();
        efov = GetComponent<EnemyFieldOfView>();
        //egd = ground.GetComponent<EnemyGroundDetector>();
        //target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (efov.canSeePlayer)
        {
            FollowPlayer();

            if (distance <= distanceToAtatck)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
        }
        else
        {
            ehm.enabled = true;
        }
    }

    void FollowPlayer()
    {
        ehm.enabled = false;

        Vector3 dir = new Vector3(target.transform.position.x - transform.position.x, 0, 0);
        distance = dir.magnitude;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }

    void ComeBack() {
        Vector3 dir = new Vector3(pointBack.position.x - transform.position.x, 0, 0);
        distance = dir.magnitude;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }
}
