using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttackGroundedState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayAirAttackGroundAnim();
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
    }

    private bool CheckIfCanIdle()
    {
        return Player.Instance._playerMovement.isGround;
    }



    public override void FixedUpdate()
    {

    }
}
