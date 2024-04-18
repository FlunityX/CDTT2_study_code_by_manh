using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayFallAnim();
        Debug.Log("fall");
        GameInput.Instance.DisableJump();
    }

    public override void ExitState()
    {
       GameInput.Instance.EnableJump();
       Player.Instance._playerMovement.isFalling= false;
    }

    public override void Update()
    {
        if (_playerStateManager.CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        
        }else if(_playerStateManager.CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
        else if (_playerStateManager.CheckIfCanAirAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerAirAttackState);
        }
        else if (_playerStateManager.CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }

    }



    public override void FixedUpdate()
    {

    }
}
