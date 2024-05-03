using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState _state;
    public IdleState idleState = new();
    public RunState runState = new();
    public JumpState jumpState = new();
    public FallState fallState = new();
   public PlayerEntryAttackState _playerEntryAttackState = new();
    public PlayerComboAttack1 _playerComboAttack1 = new();
    public PlayerComboAttack2 _playerComboAttack2 = new();
    public PlayerFinishAttack _PlayerFinishAttack = new();
    public PlayerAirAttackState _playerAirAttackState = new();
    public DashState dashState = new();
    public GetHitState GetHitState = new();
    public UsePotionState UsePotionState = new();
    public DeadState DeadState = new();

    public float airAttackTime = .05f;
    public float slideTime = 1f;
    public float jumpTime = .5f;
    public float usePotionTime = .5f;
    public float gethitTime = .1f;
    public float comboDuration = 1f;
    public float attackDuration = .5f;
    public float counter;
  
    public Vector2 entryPos;
    public Vector3 jumpEntryPos;

    private void Start()
    {
        SetUpProperties();
    }

    private void Update()
    {
        _state.Update();
    }
    private void SetUpProperties()
    {
        _state = idleState;
        _state.EnterState(this);
    }

    public void ChangeState(PlayerBaseState state)
    {
        _state.ExitState();
        _state = state;
        _state.EnterState(this);
    }

    public bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround ;
    }
    public bool CheckIfCanIdleGetHit()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround && gethitTime<=counter;
    }
    public bool CheckIfCanRun()
    {
        return Player.Instance._playerMovement.dirX != 0 && Player.Instance._playerMovement.isGround  ;
    }
    public bool CheckIfCanRunJump()
    {
        return Player.Instance._playerMovement.isRunning;
    }
    public bool CheckIfCanRunGetHit()
    {
        return (Player.Instance._playerMovement.dirX != 0 && Player.Instance._playerMovement.isGround) && gethitTime <= counter;
    }
    public bool CheckIfFallGetHit()
    {
        return Player.Instance._playerMovement.isFalling && gethitTime <= counter;
    }
    public bool CheckIfCanJump()
    {
        return GameInput.Instance.JumpPerform() ;
    }

    public bool CheckIfCanAttack()
    {
        return GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady();
    }
    public bool CheckIfCanCombo()
    {
        return GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady();

    }
    public bool CheckIfCanIdleAttack()
    {
        return counter > comboDuration;
    }
    public bool CheckIfCanAirAttack()
    {
        return !Player.Instance._playerMovement.isGround && GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady() ;
    }
    public bool CheckIfCanFall()
    {
       
        return Player.Instance._playerMovement.isFalling;
    }
    public bool CheckIfCanFallAirAttack()
    {
        return counter >= airAttackTime;
    }
    public bool CheckIfGetHit()
    {
        return Player.Instance.isGetHit;
    }
    public bool CheckIfUsePotion()
    {
        return Player.Instance.isUsePotion;
    }
    public bool CheckIfCanIdleUsePotion()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround && counter >= usePotionTime;
    }

    public bool CheckIfCanRunUsePotion()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && counter >= usePotionTime;
    }
    public bool CheckIfCanIdleEAttack()
    {
        return counter > comboDuration;
    }
    public bool CheckIfCanRunEAttack()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && counter >= attackDuration;
    }
    public bool CheckIfCanAirAttackJump()
    {
        return Player.Instance._playerMovement.isJumping && GameInput.Instance.AttackPerform() && Player.Instance._playerAttack.IsAttackingReady();
    }
    public bool CheckIfCanIdleJump()
    {
        return Player.Instance._playerMovement.isGround && counter > jumpTime;
    }
    public bool CheckIfCanIdleRun()
    {
        return Player.Instance.GetDirX() == 0;
    }

    public bool CheckIfCanDash()
    {
        return GameInput.Instance.SlidePerform() &&  Player.Instance._playerMovement.IsReadyToSlide() ;
    }
    public bool CheckIfCanIdleC2()
    {
        return counter > comboDuration;
    }

    public bool CheckIfCanIdleSlide()
    {
        return (Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround) || counter >= slideTime;
    }

    public bool CheckIfCanRunSlide()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && counter >= slideTime;
    }
    public bool CheckIfCanFallSlide()
    {
        return Player.Instance._playerMovement.isFalling;
    }
    public void NailPlayer()
    {
        Player.Instance.transform.position = entryPos;
    }

}
