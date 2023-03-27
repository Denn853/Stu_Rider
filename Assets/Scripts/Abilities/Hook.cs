using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [Header("Hook Settings")]
    public Transform startPosition;
    public float speedHook;
    public float speedToArrive;
    public float hookDistance = 5;
    public LayerMask hookMask;
    public List<Vector3> rays;

    [Header("Hook Status")]
    public bool hook = false;
    public bool isGrappling = false;

    bool isRetracting;
    float offset;
    float angle;
    Vector3 dir;
    Vector3 positionToMove;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        offset = 360 / rays.Count;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckPlatforms();

        if (Input.GetButtonDown("Hook") && hook && !isGrappling)
        {
            CoolDownController.instance.CoolDown(2);

            StartGrappling();
        }

        if (isRetracting)
        {
            Vector2 grapplePosition = Vector2.Lerp(transform.position, positionToMove, speedToArrive * Time.deltaTime);
            transform.position = grapplePosition;

            lineRenderer.SetPosition(0, transform.position);

            if (Vector2.Distance(transform.position, positionToMove) < 0.8f)
            {
                isRetracting = false;
                isGrappling = false;
                lineRenderer.enabled = false;

                CoolDownController.instance.ComeBack(2);
            }
        }
    }

    private void CheckPlatforms ()
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
    }

    private void StartGrappling()
    {
        isGrappling = true;
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;

        StartCoroutine(Grapple());
    }

    IEnumerator Grapple()
    {
        float timer = 0;
        float time = 10;

        lineRenderer.SetPosition(0, startPosition.position);
        lineRenderer.SetPosition(1, startPosition.position);

        Vector2 newPos;

        for (; timer < time; timer += speedHook * Time.deltaTime) {
            newPos = Vector2.Lerp(startPosition.position, positionToMove, timer / time);
            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, newPos);
            
            yield return null;
        }

        lineRenderer.SetPosition(1, positionToMove);
        isRetracting = true;
    }
}
