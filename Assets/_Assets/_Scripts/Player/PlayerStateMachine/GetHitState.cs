using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitState : PlayerBaseState
{
    

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayGetHitAnim();
        Player.Instance.PlayerGetHitInvoke();

        Debug.Log("get hit");
    }

    public override void ExitState()
    {
        Player.Instance.isGetHit = false;

        _playerStateManager.counter = 0;
    }

    public override void Update()
    {
        _playerStateManager.counter += Time.deltaTime;
        if (_playerStateManager.CheckIfCanIdleGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if (_playerStateManager.CheckIfCanRunGetHit())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }else if(_playerStateManager.CheckIfFallGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
    }

    public override void FixedUpdate()
    {

    }
}
