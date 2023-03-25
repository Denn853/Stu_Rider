using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{

    [Header("AttackSettings")]
    public Animator anim;

    public Transform attackPoint;
    public float attackRange;
    public float coolDown = 2f;
    
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

    public void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach(Collider2D player in hit)
        {
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
