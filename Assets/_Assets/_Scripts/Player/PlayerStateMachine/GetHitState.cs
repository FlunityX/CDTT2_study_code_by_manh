using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitState : PlayerBaseState
{
    private float gethitTime = .1f;
    private float gethitTimeCounter;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayGetHitAnim();
        Player.Instance.isGetHit = false;

        //Debug.Log("get hit");
    }

    public override void ExitState()
    {
        gethitTimeCounter = 0;
    }

    public override void Update()
    {
        gethitTimeCounter += Time.deltaTime;
        if (_playerStateManager.CheckIfCanIdle())
       {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

       }
        else if (_playerStateManager.CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
    }

    public override void FixedUpdate()
    {

    }
}
