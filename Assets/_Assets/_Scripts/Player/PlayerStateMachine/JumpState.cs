using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayJumpAnim();
        Player.Instance.PlayerJumpInvoke();
        //Debug.Log("jump");
    }

    public override void ExitState()
    {
        GameInput.Instance.DisableJump();
    }

    public override void Update()
    {
       
         if(_playerStateManager.CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
        else if (_playerStateManager.CheckIfCanAirAttackJump())
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
