using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyGetHitState : NEnemyBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayHurtAnim();
        
    }

    public override void ExitState()
    {
        _NEnemyManager.ResetCounter();
        _NEnemyManager._normalEnemy.isGetHit = false;

    }

    public override void Update()
    {
        _NEnemyManager.durationCounter += Time.deltaTime;
        if(CheckIfCanIdleGetHit())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
        }
        else if (CheckIfCanAttack())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyAttackState);
        }
    }
    private bool CheckIfCanAttack()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) <= _NEnemyManager._normalEnemy.GetEnemyStat().AttackRange * 2 && _NEnemyManager._normalEnemy.GetNEnemyAttack().IsReadyToAttack();
    }
    private  bool CheckIfCanIdleGetHit()
    {
        return _NEnemyManager.getHitDuration <= _NEnemyManager.durationCounter;
    }


    public override void FixedUpdate() { }
}
