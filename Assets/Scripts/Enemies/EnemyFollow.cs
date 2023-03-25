using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Enemy Follow Settings")]
    public GameObject target;
    public GameObject ground;
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
        //egd = ground.GetComponent<EnemyGroundDetector>();
        //target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (efov.canSeePlayer)
        {
            FollowPlayer();
        }
        else
        {
            ComeBack();
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
