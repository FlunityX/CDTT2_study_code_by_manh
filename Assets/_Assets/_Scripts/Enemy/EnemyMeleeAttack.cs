using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack :MonoBehaviour, IMeleeAttack
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private NormalEnemy _normalEnemy;

    private void Start()
    {
       // attackRange = _normalEnemy.en
    }
    public void MeleeAttack(float dmg)
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if (hit != null)
        {
            if (hit.CompareTag("Player"))
            {
                hit.GetComponent<Player>().ReduceHp(dmg);
                Player.Instance.ReduceHp(dmg);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
