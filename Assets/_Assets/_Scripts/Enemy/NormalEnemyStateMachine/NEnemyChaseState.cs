using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (CheckIfCanIdle())
      {
           _NEnemyManager.ChangeState(_NEnemyManager._NEnemyIdleState);
       }else if(CheckIfCanAttack())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyAttackState);
        }
        
        else if (_NEnemyManager.CheckIfGetHit())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyGetHitState);
        }
        
        if (CheckIfNeedChase())
        {
            Chase();

        }
        _NEnemyManager.UpdateChaseDir();
    }
    private bool CheckIfCanIdle()
    {
        return !_NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer();
        
    }

    private bool CheckIfCanAttack()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) <= _NEnemyManager._normalEnemy.GetEnemyStat().attackRange && _NEnemyManager._normalEnemy.GetNEnemyAttack().IsReadyToAttack();
    }
    private bool CheckIfNeedChase()
    {
        return Mathf.Abs(Player.Instance.transform.position.x - _NEnemyManager._normalEnemy.transform.position.x) > _NEnemyManager._normalEnemy.GetEnemyStat().attackRange ;
    }
    private void Chase()
    {
        if(ChaseDir > 0)
        {
            _NEnemyManager._normalEnemy.transform.Translate(Vector2.right * _NEnemyManager._normalEnemy.GetEnemyStat().speed * 2 * Time.deltaTime);
        }
        else{
            _NEnemyManager._normalEnemy.transform.Translate(Vector2.left * _NEnemyManager._normalEnemy.GetEnemyStat().speed * 2 * Time.deltaTime);

        }
        Debug.Log("chasing"); 
    }

   


    public override void FixedUpdate() { }
}
