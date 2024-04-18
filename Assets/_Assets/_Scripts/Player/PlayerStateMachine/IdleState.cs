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
        Player.Instance._playerMovement.canIdleFall = false;
        Player.Instance.canUsePotion = true;
        Debug.Log("idle");
    }

    public override void ExitState()
    {
        Player.Instance.canUsePotion = false;

    }

    public override void Update()
    {
        if (_playerStateManager.CheckIfCanRun()) {
            _playerStateManager.ChangeState(_playerStateManager.runState); 
        // Debug.Log("run");

        }
        else if (_playerStateManager.CheckIfCanJump()) { 
            _playerStateManager.ChangeState(_playerStateManager.jumpState);

        }
        else if (_playerStateManager.CheckIfCanAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerEntryAttackState);
        }
        else if (_playerStateManager.CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
        else if (_playerStateManager.CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }else if (  _playerStateManager.CheckIfUsePotion())
        {
            _playerStateManager.ChangeState(_playerStateManager.UsePotionState);
        }

    }

    
    public override void FixedUpdate()
    {
  
    }
}
