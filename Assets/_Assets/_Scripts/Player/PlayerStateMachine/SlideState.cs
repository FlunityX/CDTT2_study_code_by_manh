using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SlideState : PlayerBaseState
{
    private float slideTime = 2f;
    private float slideTimeCounter;
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerMovement.Slide(20f);
        Player.Instance._playerVisual.PlaySlideAnim();
    }

    public override void ExitState()
    {
        ResetSlideTimeCounter();
    }

    public override void Update()
    {
        slideTimeCounter += Time.deltaTime;
        // Player.Instance._playerMovement.IncreaseGravity();
        if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if (CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
        else if (CheckIfCanJump())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerAirAttackState);
        }

    }

    private bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround || slideTimeCounter>=slideTime;
    }

    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && slideTimeCounter >= slideTime;
    }
    private bool CheckIfCanJump()
    {
        return (GameInput.Instance.JumpPerform() && !Player.Instance._playerMovement.isGround);
    }

    private void ResetSlideTimeCounter()
    {
        slideTimeCounter = 0;
    }

    public override void FixedUpdate()
    {

    }
}
