using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    public float rotationSpeed = 2f;

    private void Update()
    {
        transform.Rotate(0, 0, 360 * rotationSpeed * Time.deltaTime);
    }
}
