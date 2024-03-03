using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEditorInternal;
using UnityEngine;

public class NEnemyPartrolState : NEnemyBaseState
{
    [SerializeField] private NormalEnemy _normalEnemy;
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {

    }

    private bool CheckIfCanChase()
    {
        if(_normalEnemy.GetNEnemyCollider().CheckIfHitPlayer())
        {
            return true;
        }
        else{
            return false;
        }
    }

    public void Move()
    {
        _normalEnemy.GetRigidBody().velocity = Vector2.right * _normalEnemy.GetEnemyStat().speed * Time.deltaTime;
        if (_normalEnemy.GetNEnemyCollider().CheckIfHitObstacle())
        {
            ChangeDirection();
            _NEnemyManager.ChangeState(_NEnemyManager.GetNEnemyIdleState());
        }
    }

    public override void ChangeDirection()
    {
        base.ChangeDirection();
        if(_normalEnemy.transform.localScale == Vector3.one)
        {
            _normalEnemy.transform.localScale =  new Vector3(-1,0,0);

        }
        else
        {
            _normalEnemy.transform.localScale = new Vector3(1, 0, 0);
        }
    }
    public override void FixedUpdate() {
        Move();
    }

}
