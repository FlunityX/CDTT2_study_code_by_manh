using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RunState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayRunAnim();
        Player.Instance._playerMovement.ResetIncreasingSpeed();
        Debug.Log("run");
         
    }

    public override void ExitState()
    {
        Player.Instance._playerMovement.ResetIncreasingSpeed();
        Player.Instance._playerMovement.isRunning = false;

    }

    public override void Update()
    {
       if(_playerStateManager.CheckIfCanIdleRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
           

        }
        else if (_playerStateManager.CheckIfCanJump())
        {
            _playerStateManager.ChangeState(_playerStateManager.jumpState);
            

        }else if(_playerStateManager.CheckIfCanDash())
        {
            _playerStateManager.ChangeState(_playerStateManager.dashState);
        }
        else if (_playerStateManager.CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }else if (_playerStateManager.CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }else if (_playerStateManager.CheckIfCanAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerEntryAttackState);
        }
    }


 
    public override void FixedUpdate()
    {
       
    }
}
