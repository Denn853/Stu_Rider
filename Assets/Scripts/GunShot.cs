using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{

    public GameObject bullet;
    HorizontalMovement owner;
    //public GameObject shotParticles;

    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<HorizontalMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) {

            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            Bullet bulletComponent = temp.GetComponent<Bullet>();

            if (owner.dir == HorizontalMovement.Directions.RIGHT || owner.dir == HorizontalMovement.Directions.NONE)
            {
                bulletComponent.dir = 1;
            }
            else {
                bulletComponent.dir = -1;
            }

            Destroy(temp, 0.8f);

        }

    }
}
