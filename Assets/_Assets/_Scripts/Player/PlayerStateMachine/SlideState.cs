using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SlideState : PlayerBaseState
{
    private float slideTime = 1.5f;
    private float slideTimeCounter;
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerMovement.Slide(15f);
        Player.Instance._playerVisual.PlaySlideAnim();
    }

    public override void ExitState()
    {
        ResetSlideTimeCounter();
    }

    public override void Update()
    {
        // Player.Instance._playerMovement.IncreaseGravity();
        if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if (CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
        else if (CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }
        slideTimeCounter += Time.deltaTime;


    }

    private bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround || slideTimeCounter>=slideTime;
    }

    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && slideTimeCounter >= slideTime;
    }

    private bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }
    private void ResetSlideTimeCounter()
    {
        slideTimeCounter = 0;
    }

    public override void FixedUpdate()
    {

    }
}
