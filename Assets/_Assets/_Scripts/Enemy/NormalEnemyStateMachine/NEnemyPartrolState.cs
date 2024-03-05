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
            ChangeDirection();
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
            
        }
    }

    public override void ChangeDirection()
    {
        base.ChangeDirection();
       /* if(_NEnemyManager._normalEnemy.transform.localScale == Vector3.one)
        {
            _NEnemyManager._normalEnemy.transform.localScale =  new Vector3(-1,1,1);
            _NEnemyManager._normalEnemy._isFacingLeft = true;
            _NEnemyManager._normalEnemy._isFacingRight = false;

        }
        else
        {
            _NEnemyManager._normalEnemy.transform.localScale = new Vector3(1, 1, 1);
            _NEnemyManager._normalEnemy._isFacingLeft = false;
            _NEnemyManager._normalEnemy._isFacingRight = true;

        }*/
    }
    public override void FixedUpdate() {
        
    }

}
