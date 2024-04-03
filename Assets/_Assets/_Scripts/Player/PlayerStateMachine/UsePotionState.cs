using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotionState : PlayerBaseState
{
   

    public override void EnterState(PlayerStateManager playerStateManager)
    {

        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayUsePotionAnim();
        _playerStateManager.entryPos = Player.Instance.transform.position;

        Player.Instance.PlayerHealInvoke();
    }

    public override void ExitState()
    {
        _playerStateManager.counter = 0;
    }

    public override void Update()
    {
        _playerStateManager.NailPlayer();

        _playerStateManager.counter += Time.deltaTime;
        Player.Instance.isUsePotion = false;

        if (_playerStateManager.CheckIfCanIdleUsePotion())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if (_playerStateManager.CheckIfCanRunUsePotion()) { 
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
    }

    public override void FixedUpdate()
    {

    }
}
