using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerMovement.AddingFallForce(8f);
        Player.Instance._playerVisual.PlayFallAnim();
        //Debug.Log("fall");
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
       // Player.Instance._playerMovement.IncreaseGravity();
        if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        
        }else if(CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
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

    private bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround;
    }

    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround);
    }
    private bool CheckIfCanAirAttack()
    {
        return !Player.Instance._playerMovement.isGround && GameInput.Instance.AttackPerform() && Player.Instance._playerMovement._boxRigidbody.velocity.y >= -1f;
    }

    private bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }

    public override void FixedUpdate()
    {

    }
}
