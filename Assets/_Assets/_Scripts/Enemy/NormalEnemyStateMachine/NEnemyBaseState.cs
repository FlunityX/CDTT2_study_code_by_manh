using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyBaseState : CharacterBaseState
{
    public  NEnemyManager _NEnemyManager;
 

   
    public override void EnterState(CharacterManager characterManager)
    {
        _NEnemyManager = (NEnemyManager)characterManager;
    }

    public override void ExitState() { }

    public override void Update() { }

    public override void FixedUpdate() { }

    public virtual void ChangeDirection() { }

}
