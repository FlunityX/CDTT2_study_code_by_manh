using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyDeadState : NEnemyBaseState
{
    private float counter;
    private float timer = 1f;
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayDeadAnim();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Update()
    {
        base.Update();
        counter += Time.deltaTime;
        if (counter > timer)
        {
            _NEnemyManager._normalEnemy.SelfDestroy();
        }

    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
