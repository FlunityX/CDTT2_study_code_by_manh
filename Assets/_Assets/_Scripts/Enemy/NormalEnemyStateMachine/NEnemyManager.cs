using DG.Tweening;
using UnityEngine;
using System.Security.Cryptography;

public class NEnemyManager : CharacterManager
{
  
    public NEnemyIdleState _NEnemyIdleState= new();
    public NEnemyPartrolState _NEnemyPartrolState= new();
    public NEnemyChaseState _NEnemyChaseState= new();
    public NEnemyAttackState _NEnemyAttackState= new();
    public NEnemyGetHitState _NEnemyGetHitState= new();
    public NEnemyKeepDistanceState _NEnemyKeepDistanceState= new();
    public NormalEnemy _normalEnemy;
    public Transform[] patrolPoint;
    public Tween tween;
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
            _normalEnemy._isFacingRight = true;
            _normalEnemy._isFacingLeft = false;

        }
        else
        {
            _normalEnemy.transform.localScale = new Vector3(1, 1, 1);
            _normalEnemy._isFacingRight = false;
            _normalEnemy._isFacingLeft = true;

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
    public void JumpBackWard()
    {
            Vector3 endValue = new Vector3(_normalEnemy.transform.position.x + 8*_normalEnemy.transform.localScale.x, _normalEnemy.transform.position.y, _normalEnemy.transform.position.z);;
        _normalEnemy.transform.DOJump(endValue, 2f, 1, .5f);
        Debug.Log("backWard");
    }

    public bool CheckIfGetHit()
    {
        return _normalEnemy.isGetHit;
    }
    public int GeneratePointIndex(int lastIndex)
    {
        int index = Random.Range(0, patrolPoint.Length);
        while(index == lastIndex)
        {
            index = Random.Range(0, patrolPoint.Length);
        }
        return index;
    }
    public void Move(int pointIndex)
    {
        tween = transform.DOMove(patrolPoint[pointIndex].position, Vector3.Distance(_normalEnemy.transform.position, patrolPoint[pointIndex].position) / _normalEnemy.GetEnemyStat().Speed)
            .OnComplete(() => ChangeState(_NEnemyIdleState));
     

    }
    public void InteruptMove()
    {
        tween.Kill(); 
    }
    public void ResetCounter()
    {
        durationCounter = 0;
    }
}
