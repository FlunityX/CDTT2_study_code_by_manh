using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCastSpellState : BossBaseState
{
   
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossSpellAttack().RangeAttack();
        _bossManager._Boss.GetBossVisual().PlayBossSpellAnim();
        Debug.Log("casr");


    }

    public override void ExitState()
    {
        base.ExitState();
        _bossManager.AttackCounterReset();
    }

    public override void Update()
    {
        _bossManager.durationCounter += Time.deltaTime;
        if (_bossManager.CheckIfCanIdleSpellAttack())
        {
            _bossManager.ChangeState(_bossManager._IdleState);
        }
    }

   




    public override void FixedUpdate()
    {


    }
}
