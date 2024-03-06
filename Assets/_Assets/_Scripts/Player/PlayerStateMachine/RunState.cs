using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RunState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager playerStateManager)
    {
       // Player.Instance._playerMovement.ResetGravity();

        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayRunAnim();
        Player.Instance._playerMovement.RestIncreasingSpeed();
        Debug.Log("run");
    }

    public override void ExitState()
    {
        Player.Instance._playerMovement.RestIncreasingSpeed();

    }

    public override void Update()
    {
       if(CheckIfNotRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
            //Debug.Log("idle");

        }
        else if (CheckIfCanJump())
        {
            _playerStateManager.ChangeState(_playerStateManager.jumpState);
            Debug.Log("jump");

        }else if(CheckIfCanSlide())
        {
            _playerStateManager.ChangeState(_playerStateManager.slideState);
        }
        else if (CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
    }

    private bool CheckIfNotRun()
    {
        return  Player.Instance.GetDirX() == 0;
    }
    private bool CheckIfCanJump()
    {
        return GameInput.Instance.JumpPerform();//&& Player.Instance._playerMovement.isGround;
    }
    private bool CheckIfCanSlide()
    {
        return GameInput.Instance.SlidePerform();
    }
    private bool CheckIfCanFall()
    {
        return Player.Instance.GetRigidbody().velocity.y < 0 && Player.Instance._playerMovement.isGround;
    }
    public override void FixedUpdate()
    {
       
    }
}
