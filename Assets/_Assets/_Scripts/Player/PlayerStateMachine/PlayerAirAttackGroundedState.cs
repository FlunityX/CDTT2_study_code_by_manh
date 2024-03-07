using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttackGroundedState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayAirAttackGroundAnim();
        CameraShake.Instance.Shake();
        Player.Instance._playerAttack.MeleeAttack(Player.Instance.Dmg);

        Debug.Log("grounded");
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
        if (CheckIfCanIdle())
        {

            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }
        else if (CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }
    }

    private bool CheckIfCanIdle()
    {
        return Player.Instance._playerMovement.isGround;
    }
    private bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }


    public override void FixedUpdate()
    {

    }
}
