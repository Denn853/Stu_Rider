using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int lifes = 3;
    public float speed = 5;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfEnemyIsDead();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void CheckIfEnemyIsDead()
    {
        if (lifes <= 0)
        {
            Death();
        }
    }
}
