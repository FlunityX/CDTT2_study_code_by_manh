using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IMeleeAttack,IRangeAttack
{
    
    private float attackCounter;
    public bool isAttackReady;

     public Transform attackPoint;
    [SerializeField] private Transform airAttackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject rangeAttackPrefab;
   

   
   
    private void Update()
    {
        attackCounter += Time.deltaTime;
    }
    public void MeleeAttack(float dmg)
    {
        StartCoroutine(DelayedMeleeAttack(dmg));
        ResetAttackCounter();
        
    }
   
   public bool IsAttackingReady() {
        return attackCounter >= Player.Instance._playerStat.AttackSpeed;
    }
   
    public void ResetAttackCounter()
    {
        attackCounter = 0;
    }

    public void RangeAttack()
    {
        Instantiate(rangeAttackPrefab, attackPoint.position, transform.rotation);
        
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position,2f);
    }*/

   
    IEnumerator DelayedMeleeAttack(float dmg)
    {
        yield return new WaitForSeconds(.2f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, 2f, _enemyLayer);
         
        if (hits != null)
        {
            foreach (Collider2D hit in hits)
            {
                Debug.Log(hit.name);
                if (hit.CompareTag(GameConstant.ENEMY_TAG))
                {
                    Player.Instance.PlayerAttackHitInvoke();

                    Player.Instance.DealDamage(hit.GetComponent<IReceiveDamage>(), dmg);
                    Player.Instance.InstantiateHitEffect(hit.transform);
                }
               
            }
        }
        else
        {
            Player.Instance.PlayerAttackInvoke();
        }

    }
}
