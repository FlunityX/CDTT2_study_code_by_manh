using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntryAttackState : PlayerBaseState
{
    private float comboDuration = 1f;
    private float attackDuration = .3f;
    private float comboDurationCounter;
    private Vector2 entryPos;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayEntryAttackAnim();
       
        entryPos = Player.Instance.transform.position;

        Player.Instance._playerAttack.MeleeAttack(Player.Instance.Dmg);
        Debug.Log("1");
        
    }

    public override void ExitState()
    {
        ResetCounter();
    }

    public override void Update()
    {
        comboDurationCounter += Time.deltaTime;
        NailPlayer();
        if (CheckIfCanCombo())
        {
            _playerStateManager.ChangeState(_playerStateManager._playerComboAttack1);
        }
        else if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }else if(CheckIfCanRun())
        {
            _playerStateManager.ChangeState(_playerStateManager.runState);
        }else if(CheckIfCanJump())
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
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && comboDurationCounter>=attackDuration;
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
    private void NailPlayer()
    {
        Player.Instance.transform.position = entryPos;
    }
    public override void FixedUpdate()
    {

    }
}
