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

    public virtual void ChangeDirection() {
        if (_NEnemyManager._normalEnemy.transform.localScale == Vector3.one)
        {
            _NEnemyManager._normalEnemy.transform.localScale = new Vector3(-1, 1, 1);
            _NEnemyManager._normalEnemy._isFacingLeft = true;
            _NEnemyManager._normalEnemy._isFacingRight = false;

        }
        else
        {
            _NEnemyManager._normalEnemy.transform.localScale = new Vector3(1, 1, 1);
            _NEnemyManager._normalEnemy._isFacingLeft = false;
            _NEnemyManager._normalEnemy._isFacingRight = true;

        }
    }

}
