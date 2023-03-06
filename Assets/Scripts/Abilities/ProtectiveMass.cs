using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveMass : MonoBehaviour
{

    public bool massIsActive = false;
    public GameObject massParticles;
    private GameObject temp;

    CircleCollider2D coll;

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
            GameManager.instance.lifes--;
            StartCoroutine(Protective_Mass_Corutine());
        }
    }

    IEnumerator Protective_Mass_Corutine()
    {

        massIsActive = true;
        coll.isTrigger = false;
        temp = Instantiate(massParticles, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.5f);
        Destroy(temp);
        massIsActive = false;
        coll.isTrigger = true;

    }
}