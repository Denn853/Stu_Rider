using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoMovement : MonoBehaviour
{

    public float maxSpeed;
    float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += Time.deltaTime / 3;
        }

        transform.position = new Vector3(transform.position.x + currentSpeed, transform.position.y, transform.position.z);
    }
}
