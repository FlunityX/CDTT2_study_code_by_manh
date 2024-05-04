using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DashState : PlayerBaseState
{
   
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        Player.Instance._playerMovement.Dash();
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlaySlideAnim();
        Player.Instance.PlayerSlideInvoke();
        Player.Instance.trailRenderer.enabled = true;
        Debug.Log("dash");
    }
    public override void ExitState()
    {
        _playerStateManager.counter = 0;
        Player.Instance._playerMovement.ResetSlideTimer();
        Player.Instance._playerMovement.canMove = true;
        Player.Instance.trailRenderer.enabled = false;
        Debug.Log("fkk this shit im out");

    }

    public override void Update()
    {

        _playerStateManager.counter += Time.deltaTime;

        if (_playerStateManager.CheckIfCanIdleSlide())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if (_playerStateManager.CheckIfCanRunSlide())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
        else if (_playerStateManager.CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }else if (_playerStateManager.CheckIfCanFallSlide())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);

        }


    }

    public override void FixedUpdate()
    {

    }
}