using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttackState : PlayerBaseState
{
   

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.entryPos = Player.Instance.transform.position;
        Player.Instance._playerVisual.PlayAirAttackAnim();
        _playerStateManager.NailPlayer();
        
        
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
        _playerStateManager.counter += Time.deltaTime;
        if (_playerStateManager.CheckIfCanFallAirAttack())
        {
            _playerStateManager.ChangeState(_playerStateManager.fallState);
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
