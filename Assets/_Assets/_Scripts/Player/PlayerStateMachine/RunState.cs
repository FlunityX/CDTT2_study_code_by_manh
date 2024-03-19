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
        Player.Instance._playerMovement.ResetIncreasingSpeed();
        Debug.Log("run");
    }

    public override void ExitState()
    {
        Player.Instance._playerMovement.ResetIncreasingSpeed();

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
        }else if (CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }else if (CheckIfCanAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerEntryAttackState);
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
    private bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }
    private bool CheckIfCanAttack()
    {
        return GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady();
    }
    public override void FixedUpdate()
    {
       
    }
}
