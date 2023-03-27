using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float destructionTime;
    public Vector3 dir = new Vector3();
    public GameObject explosion;

    EnemyController ec;
    Vector3 offset = new Vector3(2.2f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(speed * dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject temp = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(temp, destructionTime);
        }

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Walls")
        {
            GameObject temp = Instantiate(explosion, collision.transform.position - offset, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(temp, destructionTime);
        }

    }

    private void Explosion(Transform trans)
    {
        GameObject temp = Instantiate(explosion, trans.position, trans.rotation);
        Destroy(temp, 1);
    }
}

