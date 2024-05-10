
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _bossManager._Boss.GetBossVisual().PlayBossIdelAnim();
        Debug.Log("Idel");


    }

    public override void ExitState()
    {
        base.ExitState();

    }

    public override void Update()
    {
        if (_bossManager.CheckIfCanUseHidding())
        {
            _bossManager.ChangeState(_bossManager._HiddingState);
        }
        else if(_bossManager.CheckIfCanMeleeAttack())
        {
            _bossManager.ChangeState(_bossManager._MeleeAttack);
        }
        else if(_bossManager.CheckIfCanUseSpell())
        {
            _bossManager.ChangeState(_bossManager._CastSpellState);
        }
        else if(_bossManager.CheckIfNeedChase())
        {
            _bossManager.ChangeState(_bossManager._WalkState);
        }else if(_bossManager.CheckIfDead())
        {
            _bossManager.ChangeState(_bossManager._DeathState);
        }
    }

   



    public override void FixedUpdate()
    {
      

    }
}
