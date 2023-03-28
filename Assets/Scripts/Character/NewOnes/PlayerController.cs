using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Instance: Access from anywhere")]
    public static PlayerController instance;

    [Header("Player States")]
    public bool isMoving;
    public bool isGrounded;
    public bool isJumping;
    public bool isInWall;

    [Header("GameObject Components")]
    public SpriteRenderer sprite;
    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
