using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveMass : MonoBehaviour
{

    [Header("Protective Mass Settings")]
    public GameObject massParticles;
    public Animator anim;

    [Header("Protective Mass Status")]
    public bool massIsActive = false;

    CircleCollider2D coll;
    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<CircleCollider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!coll.isTrigger) {
            temp.transform.position = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !massIsActive) {
            GameManager.instance.ReceiveDamage();
            anim.SetTrigger("Hurt");
            massIsActive = true;
            StartCoroutine(Protective_Mass_Corutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !massIsActive)
        {
            GameManager.instance.ReceiveDamage();
            anim.SetTrigger("Hurt");
            massIsActive = true;
            StartCoroutine(Protective_Mass_Corutine());
        }
    }

    IEnumerator Protective_Mass_Corutine()
    {
        coll.isTrigger = false;
        temp = Instantiate(massParticles, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.5f);
        Destroy(temp);
        massIsActive = false;
        coll.isTrigger = true;

    }
}
