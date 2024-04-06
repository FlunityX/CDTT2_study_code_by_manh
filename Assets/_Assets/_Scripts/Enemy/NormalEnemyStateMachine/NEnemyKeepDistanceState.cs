using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyKeepDistanceState : NEnemyBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayIdleAnim();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    
    public override void Update()
    {
        base.Update();
        if (CheckIfCanAttack())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyAttackState);
        }else if (CheckIfCanIdle())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
        }else if(CheckIfPlayerTooClose())
        {
            _NEnemyManager.JumpBackWard();
        }
        else
        {
            return;
        }

    }
    private bool CheckIfCanAttack()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) <= _NEnemyManager._normalEnemy.GetEnemyStat().AttackRange * 2 && _NEnemyManager._normalEnemy.GetNEnemyAttack().IsReadyToAttack();
    }
    private bool CheckIfCanIdle()
    {
        return !_NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer();
    }
    private bool CheckIfPlayerTooClose()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) <= 5f && !_NEnemyManager._normalEnemy.GetNEnemyAttack().IsReadyToAttack();

    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
