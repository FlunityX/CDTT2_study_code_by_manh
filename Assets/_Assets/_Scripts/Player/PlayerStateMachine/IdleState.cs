using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
       // Player.Instance._playerMovement.ResetGravity();
        base.EnterState(playerStateManager);
    }

    public override void ExitState()
    {
        
    }
    
    public override void Update()
    {
        if (CheckIfCanRun()) {
            _playerStateManager.ChangeState(_playerStateManager.runState); 
        // Debug.Log("run");

        }
        else if (CheckIfCanJump()) { 
            _playerStateManager.ChangeState(_playerStateManager.jumpState);
           Debug.Log("To jumping");
        }
    }

    private bool CheckIfCanRun()
    {
        return Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround;  ;
    }

    private bool CheckIfCanJump()
    {
        return GameInput.Instance.JumpPerform() && Player.Instance._playerMovement.isJumping ;
    }



    public override void FixedUpdate()
    {
  
    }
}
