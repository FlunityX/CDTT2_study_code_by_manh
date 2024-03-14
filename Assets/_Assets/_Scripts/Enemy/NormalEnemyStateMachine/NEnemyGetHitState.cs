using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyGetHitState : NEnemyBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayHurtAnim();
        _NEnemyManager._normalEnemy.isGetHit= false;
        
    }

    public override void ExitState()
    {
        _NEnemyManager.ResetCounter();
    }

    public override void Update()
    {
        _NEnemyManager.durationCounter += Time.deltaTime;
        if(CheckIfCanIdleGetHit())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
        }
    }

    private  bool CheckIfCanIdleGetHit()
    {
        return _NEnemyManager.getHitDuration <= _NEnemyManager.durationCounter;
    }


    public override void FixedUpdate() { }
}
