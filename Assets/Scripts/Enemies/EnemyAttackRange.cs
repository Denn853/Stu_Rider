using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{

    [Header("AttackSettings")]
    public Animator anim;

    public Transform attackPoint;
    public float attackRange;
    public float coolDown = 2f;

    public GameObject target;
    public GameObject bullet;

    public LayerMask playerLayer;

    float timer = 0;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer && GetComponent<EnemyFollow>().canAttack)
        {
            Attack();
            timer = Time.time + coolDown;
        }
    }

    void Attack()
    {
        GameObject temp = Instantiate(bullet, attackPoint.position, attackPoint.rotation);
        EnemyBullet bulletComponent = temp.GetComponent<EnemyBullet>();
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        bulletComponent.dir = dir;
        Destroy(temp, 0.6f);
    }
}
