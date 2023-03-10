using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{

    public GameObject punchParticles;

    CapsuleCollider2D coll;
    EnemyController ec;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<CapsuleCollider2D>();
        transform.eulerAngles += new Vector3(0, 0, 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {

            GameObject temp = Instantiate(punchParticles, transform.position, transform.rotation);
            ec = collision.gameObject.GetComponent<EnemyController>();
            ec.lifes--;
            Destroy(temp, 0.45f);
        }
    }
}
