using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishAttack : PlayerBaseState
{


    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayFinishAttackAnim();
        Player.Instance._playerAttack.MeleeAttack(Player.Instance.Dmg);
        Player.Instance.PlayerAttackInvoke();
        Player.Instance._playerAttack.RangeAttack();

        Debug.Log("4");
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
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }
        else if (_playerStateManager.CheckIfCanIdleAttack())
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
