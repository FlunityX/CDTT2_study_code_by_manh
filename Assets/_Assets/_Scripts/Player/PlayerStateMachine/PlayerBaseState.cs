using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public PlayerStateManager _playerStateManager;

    public virtual void EnterState(PlayerStateManager playerStateManager) {  _playerStateManager = playerStateManager; }
    public virtual void ExitState() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}
