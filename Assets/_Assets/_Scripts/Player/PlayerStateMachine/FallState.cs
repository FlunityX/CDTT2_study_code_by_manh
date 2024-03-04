using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
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
            //s Debug.Log("ruin");

        }
        Debug.Log("fall");
    }

    private bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround;
    }

    // private bool CheckIfCanJump()
    //{
    //      return GameInput.Instance.JumpPerform() && Player.Instance._playerMovement.isGround;
    // }

    

    public override void FixedUpdate()
    {

    }
}
