using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : CharacterBaseState
{
    public BossManager _bossManager;
        



    public override void EnterState(CharacterManager characterManager)
    {
        _bossManager = (BossManager)characterManager;
    }

    public override void ExitState() { }

    public override void Update() { }

    public override void FixedUpdate() { }

   
}
