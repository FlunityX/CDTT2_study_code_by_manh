using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppearingState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossVisual().Visible();
        _bossManager._Boss.GetBossVisual().PlayBossAppearAnim();


    }

    public override void ExitState()
    {
        base.ExitState();
        _bossManager.durationCounter = 0;
    }

    public override void Update()
    {
        _bossManager.durationCounter += Time.deltaTime;
        _bossManager.UpdateChaseDir();
        _bossManager.ApproachingPlayerPos();
        if (_bossManager.CheckIfCanAttackHidding())
        {

            _bossManager.ChangeState(_bossManager._MeleeAttack);
        }
    }






    public override void FixedUpdate()
    {


    }
}
