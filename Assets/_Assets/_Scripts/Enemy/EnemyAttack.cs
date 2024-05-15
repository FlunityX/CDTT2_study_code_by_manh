using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IRangeAttack, IMeleeAttack
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private NormalEnemy _normalEnemy;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject projectivePrefab;
    [SerializeField] private Transform projectiveHolder;
    private float attackSpeedCounter;

    private void Start()
    {
        //projectivePrefab = GameManager.Instance.resourceManager.GoblinRangedArrow;
        if (_normalEnemy.GetEnemyStat()._unitSO.IsRanger)
        {
            projectivePrefab.GetComponent<EnemyProjective>().dmg = _normalEnemy.GetEnemyStat().AttackDmg;

        }
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
        Instantiate(projectivePrefab, attackPoint.position, Quaternion.Euler(0,0,Vector2.Angle(AttackDirection(),new Vector2(-1,0))),projectiveHolder);
        ResetAttackSpeedCounter();

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

    public Vector2 AttackDirection()
    {
        return new Vector2(Player.Instance.transform.position.x - attackPoint.transform.position.x, Player.Instance.transform.position.y - attackPoint.transform.position.y);
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
        PLaySound(_normalEnemy.GetEnemyStat()._unitSO.UnitName);
        if (hit != null)
        {


            if (hit.CompareTag(GameConstant.PLAYER_TAG))
            {
                // _normalEnemy.DealDamage(hit.GetComponent<IReceiveDamage>(), _normalEnemy.GetEnemyStat().AttackDmg);
                hit.GetComponent<IReceiveDamage>().ReduceHp(_normalEnemy.GetEnemyStat().AttackDmg);


            }
        }

    }
    public void PLaySound(string name)
    {
        if (name == GameConstant.PUMKIN || name == GameConstant.SPIDER)
        {
            GameManager.Instance.soundManager.PlayMob2Attack(transform.position);
        }
        else if (name == GameConstant.GLOBIN_RANGED)
        {
            GameManager.Instance.soundManager.PlayRangedGlobinAttack(transform.position);
        }
        else if (name == GameConstant.GLOBIN_SCOUT)
        {
            GameManager.Instance.soundManager.PlayScoutGlobinAttack(transform.position);
        }
        else if (name == GameConstant.GLOBIN_TANK || name == GameConstant.TOAD)
        {
            GameManager.Instance.soundManager.PlayMobAttack(transform.position);
        }
        else return;
    }
}
