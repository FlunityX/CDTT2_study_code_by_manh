using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEditorInternal;
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

        Debug.Log("enter");
        
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
        Move();
        if (CheckIfCanChase())
        {
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
    
    public void Move()
    {
        if (_NEnemyManager._normalEnemy._isFacingLeft)
        {
        _NEnemyManager._normalEnemy.transform.Translate(Vector2.left * _NEnemyManager._normalEnemy.GetEnemyStat().speed/2 * Time.deltaTime)   ;

        }
        else 
        {
            _NEnemyManager._normalEnemy.transform.Translate(Vector2.right * _NEnemyManager._normalEnemy.GetEnemyStat().speed/2 * Time.deltaTime);

        }

        if (_NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitObstacle())
        {
            _NEnemyManager.ChangeDirection();
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
            
        }
    }

    
    public override void FixedUpdate() {
        
    }

}
