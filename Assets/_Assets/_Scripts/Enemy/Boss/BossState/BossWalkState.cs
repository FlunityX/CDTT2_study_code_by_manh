using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);



    }

    public override void ExitState()
    {
        base.ExitState();

    }

    public override void Update()
    {
        if (CheckIfCanMeleeAttack())
        {
            _bossManager.ChangeState(_bossManager._MeleeAttack);  
        }
    }


    private bool CheckIfCanMeleeAttack()
    {
        return _bossManager._Boss.GetBossMeleeAttack().IsReadyToAttack() && _bossManager._Boss.attackCount < 3 && _bossManager._Boss.GetBossCollider().isPlayerInRange;
    }



    public override void FixedUpdate()
    {


    }
}
