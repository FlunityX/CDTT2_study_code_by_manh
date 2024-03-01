using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyBaseState : CharacterBaseState
{
    protected NEnemyManager _NEnemyManager;
    public override void EnterState(CharacterManager characterManager)
    {
        _NEnemyManager = (NEnemyManager)characterManager;
    }
}
