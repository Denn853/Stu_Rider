using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public int dir = 0;
    public GameObject explosion;

    EnemyController ec;
    Vector3 offset = new Vector3(2.2f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed * dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject temp = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(temp, 1);
            ec = collision.gameObject.GetComponent<EnemyController>();
            ec.lifes--;
        }

        if (collision.gameObject.tag == "Platform")
        {
            GameObject temp = Instantiate(explosion, collision.transform.position - offset, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(temp, 1);
        }

    }

    private void Explosion(Transform trans)
    {
        GameObject temp = Instantiate(explosion, trans.position, trans.rotation);
        Destroy(temp, 1);
    }
}
