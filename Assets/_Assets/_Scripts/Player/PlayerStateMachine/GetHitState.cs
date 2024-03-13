using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitState : PlayerBaseState
{
    private float gethitTime = .2f;
    private float gethitTimeCounter;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayGetHitAnim();
        //Debug.Log("get hit");
    }

    public override void ExitState()
    {
        gethitTimeCounter = 0;
    }

    public override void Update()
    {
        gethitTimeCounter += Time.deltaTime;
       Player.Instance.isGetHit = false;
        if (CheckIfCanIdle())
       {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

       }
        else if (CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
    }


    private bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround && gethitTimeCounter >=gethitTime;
    }

    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround ) && gethitTimeCounter >= gethitTime;
    }



    public override void FixedUpdate()
    {

    }
}
