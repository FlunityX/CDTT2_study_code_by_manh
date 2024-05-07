using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossVisual().PlayBossDeadAnim();


    }

    public override void ExitState()
    {
        base.ExitState();
        _bossManager.durationCounter = 0;
    }

    public override void Update()
    {
        _bossManager.durationCounter += Time.deltaTime;
        if(_bossManager.durationCounter > _bossManager.deadDuration)
        {
            _bossManager._Boss.SelfDestroy();
        }
    }






    public override void FixedUpdate()
    {


    }
}
