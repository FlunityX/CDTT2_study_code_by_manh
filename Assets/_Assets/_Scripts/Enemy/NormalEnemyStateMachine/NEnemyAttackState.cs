using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyAttackState : NEnemyBaseState
{
    private Vector3 usePos;

    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        usePos= _NEnemyManager._normalEnemy.transform.position;
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayAttackAnim();
        _NEnemyManager._normalEnemy.GetNEnemyAttack().EAttack();
        Debug.Log("Attack");
    }

    public override void ExitState()
    {
        _NEnemyManager.ResetCounter();
    }

    public override void Update()
    {
        NailPosition();
        _NEnemyManager.durationCounter += Time.deltaTime;
       if(CheckIfCanIdleAttack())
        {

        _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState );
        }else if(!CheckIfInAttackRange())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyChaseState);
        }
        else if (_NEnemyManager.CheckIfDead())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyDeadState);
        }




    }
    private bool CheckIfCanIdleAttack()
    {
        return _NEnemyManager.attackDuration < _NEnemyManager.durationCounter;
    }
    private bool CheckIfInAttackRange()
    {
        return ((Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x )<= _NEnemyManager._normalEnemy.GetEnemyStat().AttackRange) ;
    }
    private void NailPosition()
    {
        _NEnemyManager._normalEnemy.transform.position = usePos;
    }
    public override void FixedUpdate() { }
}
