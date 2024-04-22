using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossVisual().PlayBossWalkAnim();
       
        Debug.Log("chase");

    }

    public override void ExitState()
    {
        base.ExitState();

    }

    public override void Update()
    {
        _bossManager.UpdateChaseDir();
        if (!_bossManager.IsPlayerInAttackRange())
        {
            _bossManager.Chase();

        }
        if (_bossManager.CheckIfCanMeleeAttack())
        {
            _bossManager.ChangeState(_bossManager._MeleeAttack);  
        }else if(_bossManager.CheckIfCanIdle())
        {
            _bossManager.ChangeState(_bossManager._IdleState);
        }
    }


    



    public override void FixedUpdate()
    {


    }
}
