using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Directions { NONE, RIGHT, LEFT };

    [Header("Instance: Access from anywhere")]
    public static PlayerController instance;

    [Header("Player States")]
    public bool isMoving;
    public bool isGrounded;
    public bool isDashing;
    public bool isJumping;
    public bool isInWall;
    public bool isWallJump;

    [Header("Movement Direction")]
    public Directions dir = Directions.NONE;

    [Header("Wall Position")]
    public Directions walldir = Directions.NONE;

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
