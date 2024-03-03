using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyBaseState : CharacterBaseState
{
    protected NEnemyManager _NEnemyManager;
    [SerializeField] NormalEnemy _normalEnemy;

    public override void EnterState(CharacterManager characterManager)
    {
        _NEnemyManager = (NEnemyManager)characterManager;
    }

    public override void ExitState() { }

    public override void Update() { }

    public override void FixedUpdate() { }

    public virtual void ChangeDirection() { }

}
