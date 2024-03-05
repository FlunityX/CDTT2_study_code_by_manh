using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyAttackState : NEnemyBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager._normalEnemy.GetNEnemyAttack().MeleeAttack(_NEnemyManager._normalEnemy.GetEnemyStat().attackDamage);
        Debug.Log("Attack");
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
       
        _NEnemyManager.ChangeState(_NEnemyManager._NEnemyChaseState);

        
    }
    private bool CheckIfInAttackRange()
    {
        return (Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x )<= _NEnemyManager._normalEnemy.GetEnemyStat().attackRange;
    }
    public override void FixedUpdate() { }
}
