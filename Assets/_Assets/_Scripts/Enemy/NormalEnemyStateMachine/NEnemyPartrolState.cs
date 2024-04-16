using DG.Tweening;
using UnityEngine;

public class NEnemyPartrolState : NEnemyBaseState
{
    private float entryTime;
    private float restTime = 1f;
    private int pointIndex;
    private int lastPointIndex=0;

    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager = (NEnemyManager)characterManager;
        entryTime = Time.time;
        _NEnemyManager._normalEnemy.GetEnemyVisual().PlayWalkAnim();
        pointIndex = _NEnemyManager.GeneratePointIndex(lastPointIndex);
        _NEnemyManager.Move(pointIndex);

        Debug.Log("enter");
        
    }

    public override void ExitState()
    {
        lastPointIndex = pointIndex;
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
    }

    private bool CheckIfCanChase()
    {
        return _NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer();
       
    }
    
   

    
    public override void FixedUpdate() {
        
    }

}
