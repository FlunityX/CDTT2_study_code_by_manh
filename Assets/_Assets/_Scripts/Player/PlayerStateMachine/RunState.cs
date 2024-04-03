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
        Player.Instance.isWalking = true;   
    }

    public override void ExitState()
    {
        Player.Instance._playerMovement.ResetIncreasingSpeed();
        Player.Instance.isWalking = false;

    }

    public override void Update()
    {
       if(_playerStateManager.CheckIfCanIdleRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
            //Debug.Log("idle");

        }
        else if (_playerStateManager.CheckIfCanJump())
        {
            _playerStateManager.ChangeState(_playerStateManager.jumpState);
            Debug.Log("jump");

        }else if(_playerStateManager.CheckIfCanSlide())
        {
            _playerStateManager.ChangeState(_playerStateManager.slideState);
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

   
   /* private bool CheckIfCanFall()
    {
        return Player.Instance.GetRigidbody().velocity.y < 0 && Player.Instance._playerMovement.isGround;
    }*/
 
    public override void FixedUpdate()
    {
       
    }
}
