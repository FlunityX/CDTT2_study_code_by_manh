using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyAttackState : NEnemyBaseState
{
    private Vector3 usePos;

    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayAttackAnim();
        _NEnemyManager._normalEnemy.GetNEnemyAttack().MeleeAttack(_NEnemyManager._normalEnemy.GetEnemyStat().attackDamage);
        usePos= _NEnemyManager._normalEnemy.transform.position;
        Debug.Log("Attack");
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
        NailPosition();
        _NEnemyManager.attackDuration += Time.deltaTime;
       if(CheckIfCanIdleAttack())
        {

        _NEnemyManager.ChangeState(_NEnemyManager._NEnemyChaseState);
        }else if(!CheckIfInAttackRange())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyChaseState);
        }
        


    }
    private bool CheckIfCanIdleAttack()
    {
        return _NEnemyManager.attackDuration >= _NEnemyManager.durationCounter;
    }
    private bool CheckIfInAttackRange()
    {
        return (Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x )<= _NEnemyManager._normalEnemy.GetEnemyStat().attackRange;
    }
    private void NailPosition()
    {
        _NEnemyManager._normalEnemy.transform.position = usePos;
    }
    public override void FixedUpdate() { }
}
