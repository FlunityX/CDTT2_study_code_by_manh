using DG.Tweening;
using UnityEngine;

public class NEnemyPartrolState : NEnemyBaseState
{
    private float entryTime;
    private float restTime = 1f;
    

    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager = (NEnemyManager)characterManager;
        entryTime = Time.time;
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayWalkAnim();
        _NEnemyManager.Move();
        _NEnemyManager.GenerateNewPatrolIndex();
        Debug.Log("enter");
        
    }

    public override void ExitState()
    {
       _NEnemyManager.ChangeDirection();
    }

    public override void Update()
    {
        if (CheckIfCanChase())
        {
            _NEnemyManager.InteruptMove();
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyChaseState);
        } else if (_NEnemyManager.CheckIfGetHit())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyGetHitState);
        }
        else if (_NEnemyManager.CheckIfDead())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyDeadState);
        }
    }

    private bool CheckIfCanChase()
    {
        return _NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer();
       
    }
    
   

    
    public override void FixedUpdate() {
        
    }

}
