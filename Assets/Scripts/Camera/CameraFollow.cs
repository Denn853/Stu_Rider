using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Target To Follow")]
    public GameObject target;

    [Header("Follow Settings")]
    public float speed;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(target.transform.position, transform.position, speed * Time.deltaTime);
    }
}
