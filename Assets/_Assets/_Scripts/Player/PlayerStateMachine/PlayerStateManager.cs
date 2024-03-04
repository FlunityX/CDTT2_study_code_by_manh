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
