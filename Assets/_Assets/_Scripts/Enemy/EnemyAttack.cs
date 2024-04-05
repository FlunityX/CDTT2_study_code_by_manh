using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IRangeAttack, IMeleeAttack
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private NormalEnemy _normalEnemy;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject projectivePrefab;
    private float attackSpeedCounter;

    private void Start()
    {
        EnemyProjective enemyProjective = projectivePrefab.GetComponent<EnemyProjective>();
        enemyProjective.dmg = _normalEnemy.GetEnemyStat().AttackDmg;
    }
    public void EAttack()
    {
        if (_normalEnemy.GetEnemyStat()._unitSO.IsRanger)
        {
            RangeAttack();
        }
        else
        {
            MeleeAttack(_normalEnemy.GetEnemyStat().AttackDmg);
        }
    }
    public void RangeAttack()
    {
        Instantiate(projectivePrefab, attackPoint.position, transform.rotation);
    }

    private void Update()
    {
        attackSpeedCounter += Time.deltaTime;

    }
    public void MeleeAttack(float dmg)
    {
        StartCoroutine(DelayedMeleeAttack(dmg));
        ResetAttackSpeedCounter();

    }


    public bool IsReadyToAttack()
    {
        return attackSpeedCounter > _normalEnemy.GetEnemyStat().AttackSpeed;
    }
    private void ResetAttackSpeedCounter()
    {
        attackSpeedCounter = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, _normalEnemy.GetEnemyStat().AttackRange / 2f);
    }
    IEnumerator DelayedMeleeAttack(float dmg)
    {
        yield return new WaitForSeconds(.3f);
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, _normalEnemy.GetEnemyStat().AttackRange / 2f, playerLayer);
        if (hit != null)
        {


            if (hit.CompareTag(GameConstant.PLAYER_TAG))
            {
                // _normalEnemy.DealDamage(hit.GetComponent<IReceiveDamage>(), _normalEnemy.GetEnemyStat().AttackDmg);
                hit.GetComponent<IReceiveDamage>().ReduceHp(_normalEnemy.GetEnemyStat().AttackDmg);


            }
        }

    }
}
