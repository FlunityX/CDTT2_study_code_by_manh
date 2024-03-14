using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class NEnemyManager : CharacterManager
{
  
    public NEnemyIdleState _NEnemyIdleState= new();
    public NEnemyPartrolState _NEnemyPartrolState= new();
    public NEnemyChaseState _NEnemyChaseState= new();
    public NEnemyAttackState _NEnemyAttackState= new();
    public NEnemyGetHitState _NEnemyGetHitState= new();
    public NormalEnemy _normalEnemy;
    private float ChaseDir;
    public float getHitDuration = .2f;
    public float attackDuration = .5f;

    public float durationCounter;
    /*  public NEnemyIdleState GetNEnemyIdleState() { return _NEnemyIdleState; }
      public NEnemyAttackState GetNEnemyAttackState() { return _NEnemyAttackState; }
      public NEnemyChaseState GetNEnemyChaseState() { return _NEnemyChaseState;}
      public NEnemyGetHitState GetNEnemyGetHitState() { return _NEnemyGetHitState;}
      public NEnemyPartrolState GetNEnemyPartrolState() { return _NEnemyPartrolState;}*/


    private void Start()
    {
        SetUpProperties();
    }
    protected override void Update()
    {
        base.Update();
    }
    private void SetUpProperties()
    {
        _state = _NEnemyIdleState;
        _state.EnterState(this);
    }
    public  void ChangeDirection()
    {
        if (_normalEnemy.transform.localScale == Vector3.one)
        {
            _normalEnemy.transform.localScale = new Vector3(-1, 1, 1);
            _normalEnemy._isFacingLeft = true;
            _normalEnemy._isFacingRight = false;

        }
        else
        {
            _normalEnemy.transform.localScale = new Vector3(1, 1, 1);
            _normalEnemy._isFacingLeft = false;
            _normalEnemy._isFacingRight = true;

        }
    }
    public void UpdateChaseDir()
    {
        ChaseDir = Player.Instance.transform.position.x - _normalEnemy.transform.position.x;
        if (ChaseDir > 0)
        {
            _normalEnemy.transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            _normalEnemy.transform.localScale = new Vector3(1, 1, 1);

        }

    }

    public bool CheckIfGetHit()
    {
        return _normalEnemy.isGetHit;
    }

    public void ResetCounter()
    {
        durationCounter = 0;
    }
}
