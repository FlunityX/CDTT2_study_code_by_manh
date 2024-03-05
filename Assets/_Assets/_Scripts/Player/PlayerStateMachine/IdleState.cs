using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
       // Player.Instance._playerMovement.ResetGravity();
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayerIdleAnim();
        Debug.Log("idle");
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

        }
        else if (CheckIfCanAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerEntryAttackState);
        }else if (CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
       
    }

    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround);  
    }

    private bool CheckIfCanJump()
    {
        return (GameInput.Instance.JumpPerform() && !Player.Instance._playerMovement.isGround) ;
    }

    private bool CheckIfCanAttack()
    {
        return GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady();
    }
    private bool CheckIfCanFall()
    {
        return Player.Instance.GetRigidbody().velocity.y < 0;
    }

    public override void FixedUpdate()
    {
  
    }
}
