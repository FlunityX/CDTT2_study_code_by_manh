using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
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
       /* if (CheckIfCanRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
           //s Debug.Log("ruin");

        }
        else*/ if(CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
    }

    /*private bool CheckIfCanRun()
    {
        return Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround;
    }*/
    private bool CheckIfCanFall()
    {
        return Player.Instance.GetRigidbody().velocity.y < 0;
    }

   // private bool CheckIfCanJump()
    //{
  //      return GameInput.Instance.JumpPerform() && Player.Instance._playerMovement.isGround;
   // }



    public override void FixedUpdate()
    {

    }
}
