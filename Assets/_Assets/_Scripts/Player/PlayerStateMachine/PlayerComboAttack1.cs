using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerComboAttack1 : PlayerBaseState
{

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayComboAttack1Anim();
       // Player.Instance._playerVisual.PlayerIdleAnim();
        Player.Instance._playerAttack.MeleeAttack(Player.Instance.Dmg);



        Debug.Log("2");
    }

    public override void ExitState()
    {
        _playerStateManager.counter = 0;
    }

    public override void Update()
    {
        _playerStateManager.counter += Time.deltaTime;
        if (_playerStateManager.CheckIfCanCombo())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerComboAttack2);
        }else if(_playerStateManager.CheckIfCanIdleAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }
        else if (_playerStateManager.CheckIfCanRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
        }
        else if (_playerStateManager.CheckIfCanJump())
        {
            _playerStateManager.ChangeState(_playerStateManager.jumpState);
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
