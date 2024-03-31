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
       // attackRange = _boss.GetEnemyStat().attackRange;   
    }
    private void Update()
    {
        if(attackSpeedCounter< _boss.GetEnemyStat().AttackSpeed)
        {
        attackSpeedCounter += Time.deltaTime;

        }


    }
    public void MeleeAttack(float dmg)
    {
        StartCoroutine(DelayedAttack(dmg));
        
        ResetAttackSpeedCounter();
        _boss.attackCount++;
       
        

       
        
    }

    public bool IsReadyToAttack()
    {
        return attackSpeedCounter >= _boss.GetEnemyStat().AttackSpeed;
    }
    private void ResetAttackSpeedCounter()
    {
        attackSpeedCounter = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, _boss.GetEnemyStat().AttackRange);
    }

    IEnumerator  DelayedAttack(float dmg) 
    {
        yield return new WaitForSeconds(.3f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, _boss.GetEnemyStat().AttackRange, playerLayer);
        if (hits != null)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag(GameConstant.PLAYER_TAG))
                {
                    _boss.DealDamage(hit.GetComponent<IReceiveDamage>(), dmg);



                    Debug.Log(hit.name);
                }
            }
        }

    }
}
