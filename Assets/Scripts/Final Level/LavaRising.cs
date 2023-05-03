using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    [SerializeField] private float lavaSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * lavaSpeed;
    }
}

