using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMoto : MonoBehaviour
{
    [Header("Camera Settings")]
    public GameObject target;
    public float speed;
    public float offsetX;
    public float offsetY;

    public Vector3 offset;
    Rigidbody2D rb;
    GroundDetector2 gd;

    // Start is called before the first frame update
    void Start()
    {
        rb = target.GetComponent<Rigidbody2D>();
        gd = target.GetComponent<GroundDetector2>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = new Vector3(0, offsetY, -10);
        offset += Vector3.right * offsetX;
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);
    }
}
