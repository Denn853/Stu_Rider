using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{

    public GameObject bullet;
    HorizontalMovement owner;
    //public GameObject shotParticles;
    public bool hasShooted;

    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<HorizontalMovement>();
        hasShooted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("GunShot")) {

            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            Bullet bulletComponent = temp.GetComponent<Bullet>();

            if (owner.dir == HorizontalMovement.Directions.RIGHT || owner.dir == HorizontalMovement.Directions.NONE)
            {
                bulletComponent.dir = 1;
            }
            else {
                bulletComponent.dir = -1;
            }

            StartCoroutine(Shoot_Corutine());

            Destroy(temp, 0.8f);

        }

    }

    IEnumerator Shoot_Corutine()
    {
        hasShooted = true;
        yield return new WaitForSeconds(0.6f);
        hasShooted = false;
    }

}
