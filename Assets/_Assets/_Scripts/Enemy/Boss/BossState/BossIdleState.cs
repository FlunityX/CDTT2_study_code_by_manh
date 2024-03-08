using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class BossIdleState : BossBaseState
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
       if(CheckIfCanMeleeAttack())
        {
            _bossManager.ChangeState(_bossManager._MeleeAttack);
        }else if(CheckIfCanUseSpell())
        {
            _bossManager.ChangeState(_bossManager._CastSpellState);
        }else if(CheckIfNeedChase())
        {
            _bossManager.ChangeState(_bossManager._WalkState);
        }
    }

    private bool CheckIfCanMeleeAttack()
    {
        return _bossManager._Boss.GetBossMeleeAttack().IsReadyToAttack() && _bossManager._Boss.attackCount <3 && _bossManager._Boss.GetBossCollider().isPlayerInRange;
    }
    private bool CheckIfCanUseSpell()
    {
        return _bossManager._Boss.GetBossMeleeAttack().IsReadyToAttack() && _bossManager._Boss.attackCount == 3;
    }

    private bool CheckIfNeedChase()
    {
        return _bossManager._Boss.GetBossCollider().isPlayerInRange;
    }



    public override void FixedUpdate()
    {
      

    }
}
