using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttackState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossMeleeAttack().MeleeAttack(_bossManager._Boss.GetEnemyStat().AttackDmg);
        _bossManager._Boss.GetBossVisual().PlayBossAttackAnim();
        Debug.Log("mmeeee");


    }

    public override void ExitState()
    {
        base.ExitState();
        _bossManager.AttackCounterReset();

    }

    public override void Update()
    {
        _bossManager.durationCounter += Time.deltaTime;
        if (_bossManager.CheckIfCanIdleMeleeAttack())
        {
            _bossManager.ChangeState(_bossManager._IdleState);
        }
    }

   





    public override void FixedUpdate()
    {


    }
}
