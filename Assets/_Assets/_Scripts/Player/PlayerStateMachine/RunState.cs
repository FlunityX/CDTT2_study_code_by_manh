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
        Debug.Log("run");
    }

    public override void ExitState()
    {
       
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


    public override void FixedUpdate()
    {
       
    }
}
