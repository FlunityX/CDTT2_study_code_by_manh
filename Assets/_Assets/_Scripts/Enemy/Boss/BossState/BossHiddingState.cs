using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BossHiddingState : BossBaseState 
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossCollider().ImmuteAttack();
        _bossManager._Boss.GetBossVisual().PlayBossDisappearAnim();
    }

    public override void ExitState()
    {
        _bossManager._Boss.GetBossCollider().UnimmuteAttack();
        _bossManager._Boss.canUseHidding = false;
        _bossManager.durationCounter = 0;
        base.ExitState();

    }

    public override void Update()
    {
        _bossManager.durationCounter += Time.deltaTime;
        if(_bossManager.durationCounter > 3f)
        {
            _bossManager.UpdateChaseDir();
            _bossManager.ApproachingPlayerPos();

        }

        if (_bossManager.CheckIfCanAppear())
        {
            _bossManager.ChangeState(_bossManager._AppearingState);
        }
            
        

    }
    





    public override void FixedUpdate()
    {


    }
}
