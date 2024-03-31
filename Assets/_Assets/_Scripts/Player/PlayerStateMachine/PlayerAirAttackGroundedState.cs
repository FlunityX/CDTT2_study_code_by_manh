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
        Player.Instance._playerAttack.MeleeAttack(Player.Instance._playerStat.AttackDmg);

        Debug.Log("grounded");
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
        if (_playerStateManager.CheckIfCanIdleAAGround())
        {

            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }
        else if (_playerStateManager.CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }
    }




    public override void FixedUpdate()
    {

    }
}
