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
       /* if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
           //s Debug.Log("ruin");

        }*/
         if(CheckIfCanFall())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
        }
        
    }

  
    private bool CheckIfCanFall()
    {
        return Player.Instance.GetRigidbody().velocity.y < 0;
    }
  


    public override void FixedUpdate()
    {

    }
}
