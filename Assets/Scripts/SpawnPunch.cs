using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPunch : MonoBehaviour
{

    public bool canPuch = true;
    public float punchTime;
    //public float coolDownTime;
    public GameObject arm;

    SpriteRenderer sr;
    CapsuleCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        sr = arm.GetComponent<SpriteRenderer>();
        coll = arm.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("Punch") && canPuch)
        {

            StartCoroutine(Punch_Corutine());

        }
    }

    IEnumerator Punch_Corutine()
    {

        sr.enabled = true;
        coll.enabled = true;
        canPuch = false;

        yield return new WaitForSeconds(punchTime);

        sr.enabled = false;
        coll.enabled = false;
        canPuch = true;

    }
}
