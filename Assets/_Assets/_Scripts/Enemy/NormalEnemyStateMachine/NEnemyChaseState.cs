using DG.Tweening;
using UnityEngine;


public class NEnemyChaseState : NEnemyBaseState
{
    private float ChaseDir;
    
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        ChaseDir = Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x;
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayWalkAnim();



        Debug.Log("chase");
   
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
        if (CheckIfNeedChase())
        {
            _NEnemyManager.Chase();
        }
        else if (CheckIfCanAttack())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyAttackState);
        }
        else if (CheckIfGetHit())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyGetHitState);
        }else if (CheckIfCanIdle())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
        }
        else if (_NEnemyManager.CheckIfDead())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyDeadState);
        }

        _NEnemyManager.UpdateChaseDir(Player.Instance.transform);
    }
    private bool CheckIfCanIdle()
    {
        return !_NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer();
        
    }

    private bool CheckIfCanAttack()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) <= _NEnemyManager._normalEnemy.GetEnemyStat().AttackRange *2 && _NEnemyManager._normalEnemy.GetNEnemyAttack().IsReadyToAttack();
    }
    private bool CheckIfNeedChase()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) > _NEnemyManager._normalEnemy.GetEnemyStat().AttackRange && _NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer() ;
    }
    
    public bool CheckIfGetHit()
    {
        return _NEnemyManager._normalEnemy.isGetHit;
    }

  

   


    public override void FixedUpdate() { }
}
