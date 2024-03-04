using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishAttack : PlayerBaseState
{
    private float comboDuration = .3f;
    private float comboDurationCounter;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayFinishAttackAnim();
        Player.Instance._playerAttack.MeleeAttack(Player.Instance.Dmg);

        Debug.Log("4");
    }

    public override void ExitState()
    {
        ResetCounter();
    }

    public override void Update()
    {
        if (CheckIfCanCombo())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);
        }
        else if (CheckIfCanIdle())
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
        comboDurationCounter += Time.deltaTime;
    }

    private bool CheckIfCanCombo()
    {
        return comboDurationCounter <= comboDuration && GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady();

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
    private void ResetCounter()
    {
        comboDurationCounter = 0f;
    }
   
    public override void FixedUpdate()
    {

    }
}
