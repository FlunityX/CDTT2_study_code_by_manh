using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHiddingState : BossBaseState 
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossCollider().ImmuteAttack();
        _bossManager._Boss.GetBossVisual().Invisible();

    }

    public override void ExitState()
    {
        base.ExitState();
        _bossManager._Boss.GetBossCollider().UnimmuteAttack();
        _bossManager._Boss.GetBossVisual().Visible();

    }

    public override void Update()
    {
        _bossManager.durationCounter += Time.deltaTime;
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
