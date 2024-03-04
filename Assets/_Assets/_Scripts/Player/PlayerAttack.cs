using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IMeleeAttack
{
    private float attackSpeed = 1.5f;
    private float attackCounter;

    public bool isAttackReady;
    [SerializeField] private Transform attackPoint;

    [SerializeField] private LayerMask _enemyLayer;

    private void Update()
    {
        attackCounter += Time.deltaTime;
    }
    public void MeleeAttack(float dmg)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position,2f,_enemyLayer);
        if(hits != null)
        {
            foreach(Collider2D hit in hits) {
                if (hit.CompareTag("Enemy"))
                {
                    hit.GetComponent<IReceiveDamage>().ReduceHp(dmg);
                } 
            }
        }
        ResetAttackCounter();
    }
   public bool IsAttackingReady() {
        return attackCounter >= attackSpeed;
    }
    public void ResetAttackCounter()
    {
        attackCounter = 0;
    }
}
