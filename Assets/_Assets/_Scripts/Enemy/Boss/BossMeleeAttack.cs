using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttack : MonoBehaviour,IMeleeAttack
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField]private Boss _boss;
   [SerializeField] private float attackSpeedCounter;

    private void Start()
    {
        
        _boss = GetComponentInParent<Boss>();
    }
    private void Update()
    {
        attackSpeedCounter += Time.deltaTime;


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
        ResetAttackSpeedCounter();
        _boss.attackCount++;
       
        

       
        
    }

    public bool IsReadyToAttack()
    {
        return attackSpeedCounter >= _boss.GetEnemyStat().attackSpeed;
    }
    private void ResetAttackSpeedCounter()
    {
        attackSpeedCounter = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
