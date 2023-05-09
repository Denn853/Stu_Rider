using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    public float lenght;
    public float startPosition;
    public Camera cam;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * speed);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
    }
}
