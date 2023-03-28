using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Forces")]
    public float jumpForce;
    public float fallSpeed;

    [Header("Particles")]
    public GameObject dustParticles;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && PlayerController.instance.isGrounded)
        {

        }
    }
}
