using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{

    [Header("Enemy Field of View Settings")]
    public float radius = 5f;
    [Range (1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject player;

    [Header("Enemy FoV Status")]
    public bool canSeePlayer;

    EnemyHorizontalMovement ehm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ehm = GetComponent<EnemyHorizontalMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView();
    }

    private void FieldOfView ()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (!Physics2D.Raycast(transform.position, target.position, distanceToTarget, obstructionLayer))
                canSeePlayer = true;
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        if (canSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}
