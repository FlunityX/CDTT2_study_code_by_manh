using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : CharacterBaseState
{
    public BossManager _bossManager
        ;



    public override void EnterState(CharacterManager characterManager)
    {
        _bossManager = (BossManager)characterManager;
    }

    public override void ExitState() { }

    public override void Update() { }

    public override void FixedUpdate() { }

    public virtual void ChangeDirection()
    {
       if (_bossManager._Boss.transform.localScale == Vector3.one)
        {
            _bossManager._Boss.transform.localScale = new Vector3(-1, 1, 1);
            _bossManager._Boss.transform._isFacingLeft = true;
            _bossManager._Boss.transform._isFacingRight = false;

        }
        else
        {
            _NEnemyManager._normalEnemy.transform.localScale = new Vector3(1, 1, 1);
            _NEnemyManager._normalEnemy._isFacingLeft = false;
            _NEnemyManager._normalEnemy._isFacingRight = true;

        }
    }
}
