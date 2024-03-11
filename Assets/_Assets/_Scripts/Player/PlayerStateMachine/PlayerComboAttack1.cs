using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerComboAttack1 : PlayerBaseState
{

    private float comboDuration = .5f;
    private float comboDurationCounter;



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
        ResetCounter();
    }

    public override void Update()
    {
        comboDurationCounter += Time.deltaTime;
        if (CheckIfCanCombo())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerComboAttack2);
        }else if(CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }
        else if (CheckIfCanRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
        }
        else if (CheckIfCanJump())
        {
            _playerStateManager.ChangeState(_playerStateManager.jumpState);
        }
        else if (CheckIfGetHit())
        {
            _playerStateManager.ChangeState(_playerStateManager.GetHitState);
        }
    }

    private bool CheckIfCanCombo()
    {
        return  GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady(); 

    }
    private bool CheckIfCanIdle()
    {
        return comboDurationCounter > comboDuration;
    }
    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround);
    }
    private bool CheckIfCanJump()
    {
        return (GameInput.Instance.JumpPerform() && !Player.Instance._playerMovement.isGround);
    }
    private bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }
    private void ResetCounter()
    {
        comboDurationCounter = 0f;
    }


    public override void FixedUpdate()
    {

    }
}
