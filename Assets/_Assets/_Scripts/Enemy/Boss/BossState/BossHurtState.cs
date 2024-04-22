using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossVisual().PlayBossHurtAnim();



    }

    public override void ExitState()
    {
        base.ExitState();
        _bossManager.AttackCounterReset();
    }

    public override void Update()
    {
        if (_bossManager.CheckIfCanUseHidding())
        {
            _bossManager.ChangeState(_bossManager._HiddingState);
        }
        else
        if (_bossManager.CheckIfCanIdleGetHit())
        {
            _bossManager.ChangeState(_bossManager._IdleState);
        }
    }






    public override void FixedUpdate()
    {


    }
}
