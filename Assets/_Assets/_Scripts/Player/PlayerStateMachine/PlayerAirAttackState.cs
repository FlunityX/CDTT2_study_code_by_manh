using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttackState : PlayerBaseState
{
   

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayAirAttackAnim();

        Player.Instance._playerMovement.AddingFallForce(10f);
        
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
        if (_playerStateManager.CheckIfCanGrounded())
        {

        _playerStateManager.ChangeState(_playerStateManager._playerAirAttackGroundedState);
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
