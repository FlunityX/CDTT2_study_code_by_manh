using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntryAttackState : PlayerBaseState
{

    

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayEntryAttackAnim();
        Player.Instance._playerMovement.canMove = false;
        //Player.Instance._playerMovement.InteruptMovement();

        Player.Instance._playerAttack.MeleeAttack(Player.Instance._playerStat.AttackDmg);
        Player.Instance.PlayerAttackInvoke();

        Debug.Log("1");
        
    }

    public override void ExitState()
    {
        _playerStateManager.counter = 0;
        Player.Instance._playerMovement.canMove = true;


    }

    public override void Update()
    {
        _playerStateManager.counter += Time.deltaTime;
        
        if (_playerStateManager.CheckIfCanCombo())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerComboAttack1);
        }
        else if (_playerStateManager.CheckIfCanIdleEAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if(_playerStateManager.CheckIfCanRunEAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
        }else if(_playerStateManager.CheckIfCanJump())
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
