using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayDeadAnim();
    }

    public override void ExitState()
    {
       

    }

    public override void Update()
    {
       

    }
}
