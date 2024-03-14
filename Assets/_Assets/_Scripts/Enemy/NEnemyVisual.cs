using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyVisual : MonoBehaviour
{
    private Animator animator;
    private NormalEnemy _normalEnemy;
    private void Start()
    {
        animator = GetComponent<Animator>();
        _normalEnemy = GetComponentInParent<NormalEnemy>();
    }

    public void PlayIdleAnim()
    {
        animator.CrossFade(_normalEnemy.GetEnemyStat().GetUnitSO().UnitName + "_idle", .2f, 0);
    }public void PlayWalkAnim()
    {
        animator.CrossFade(_normalEnemy.GetEnemyStat().GetUnitSO().UnitName + "_walk", .2f, 0);
    }public void PlayAttackAnim()
    {
        animator.CrossFade(_normalEnemy.GetEnemyStat().GetUnitSO().UnitName + "_attack", .2f, 0);
        
    }public void PlayHurtAnim()
    {
        animator.CrossFade(_normalEnemy.GetEnemyStat().GetUnitSO().UnitName + "_hurt", .2f, 0);
    }
}
