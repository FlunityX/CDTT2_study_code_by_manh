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
    public PlayerAirAttackGroundedState _playerAirAttackGroundedState = new();
    public SlideState slideState = new();


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

 

}
