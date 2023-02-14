using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPunch : MonoBehaviour
{

    public bool canPuch = true;
    public float punchTime;
    //public float coolDownTime;
    public GameObject arm;
    public Vector3 offset;

    SpriteRenderer sr;
    CapsuleCollider2D coll;
    HorizontalMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        sr = arm.GetComponent<SpriteRenderer>();
        coll = arm.GetComponent<CapsuleCollider2D>();
        playerMovement = GetComponent<HorizontalMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPuch)
        {
            punchTime -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Punch") && canPuch)
        {
            if (playerMovement.dir == HorizontalMovement.Directions.NONE || playerMovement.dir == HorizontalMovement.Directions.RIGHT)
            {
                offset = new Vector3(0.7f, 0, -1);
            }
            else {
                offset = new Vector3(-0.7f, 0, -1);
            }

            GameObject temp = Instantiate(arm, transform.position + offset, transform.rotation);
            temp.transform.parent = transform;
            canPuch = false;
            Destroy(temp, punchTime);

        }

        if (punchTime <= 0.0f)
        {
            canPuch = true;
            punchTime = 0.35f;
        }
    }
}
