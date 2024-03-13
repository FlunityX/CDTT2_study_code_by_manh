using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayJumpAnim();
        Debug.Log("jump");
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
       /* if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
           //s Debug.Log("ruin");

        }*/
         if(CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
        else if (CheckIfCanAirAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerAirAttackState);
        }
        else if (CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }

    }

  
    private bool CheckIfCanFall()
    {
        return Player.Instance.GetRigidbody().velocity.y < 0;
    }
    private bool CheckIfCanAirAttack()
    {
        return Player.Instance._playerMovement.isJumping && GameInput.Instance.AttackPerform() && Player.Instance._playerMovement._boxRigidbody.velocity.y <=2f;
    }
    private bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }


    public override void FixedUpdate()
    {

    }
}
