using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : MonoBehaviour
{
    [SerializeField]protected PlayerStateManager _playerStateManager;

    public virtual void EnterState(PlayerStateManager playerStateManager) {  _playerStateManager = playerStateManager; }
    public virtual void ExitState() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}
