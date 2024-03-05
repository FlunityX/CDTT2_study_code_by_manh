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
        Debug.Log("air strike!!!");
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
        if (CheckIfCanGrounded())
        {

        _playerStateManager.ChangeState(_playerStateManager._playerAirAttackGroundedState);
        }
    }

    private bool CheckIfCanGrounded()
    {
        return Player.Instance._playerCollider.AirAttackGroundCheck();
    }
    
    

    public override void FixedUpdate()
    {

    }
}
